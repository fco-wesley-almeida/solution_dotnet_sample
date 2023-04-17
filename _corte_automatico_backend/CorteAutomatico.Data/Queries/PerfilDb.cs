using System.Data;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.Perfil.Dtos;
using CorteAutomatico.Core.Modules.Perfil.Queries;
using Dapper;

namespace CorteAutomatico.Data.Queries;

public class PerfilDb : IPerfilDb
{
    private readonly IDbConnection _db;

    public PerfilDb(IDbConnection db)
    {
        _db = db;
    }

    public async Task<PerfilDto?> FindByUuidAsync(Guid uuid)
    {
        const string sql = @"
            select
                uuid as Uuid
                ,nome as Nome
                ,criado_por as CriadoPor
                ,criado_em as CriadoEm
                ,modificado_por as ModificadoPor
                ,modificado_em as ModificadoEm
                ,ativo as Ativo
            from
                perfil
            where uuid = :uuid 
            order by nome
        ";
        var binds = new { uuid = uuid };
        return await _db.QueryFirstOrDefaultAsync<PerfilDto>(sql, binds);
    }

    public async Task<IEnumerable<PerfilDto>> FindAllAsync()
    {
        const string sql = @"
            select
                uuid as Uuid
                ,nome as Nome
                ,criado_por as CriadoPor
                ,criado_em as CriadoEm
                ,modificado_por as ModificadoPor
                ,modificado_em as ModificadoEm
                ,ativo as Ativo
            from
                perfil
            order by nome
        ";
        return await _db.QueryAsync<PerfilDto>(sql);
    }

    public Task<IEnumerable<PerfilDto>> FindAllAsync(Search search)
    {
        const string sql = @"
            select
                uuid as Uuid
                ,nome as Nome
                ,criado_por as CriadoPor
                ,criado_em as CriadoEm
                ,modificado_por as ModificadoPor
                ,modificado_em as ModificadoEm
                ,ativo as Ativo
            from
                perfil
            where
                nome ilike :search
            order by nome
        ";
        var binds = new { search = search.ToString() };
        return _db.QueryAsync<PerfilDto>(sql, binds);
    }

    public async Task<PaginatedList<PerfilDto>> FindAllAsync(Pagination pagination)
    {
        var query = await _db.QueryMultipleAsync($@"
            select
                uuid as Uuid
                ,nome as Nome
                ,criado_por as CriadoPor
                ,criado_em as CriadoEm
                ,modificado_por as ModificadoPor
                ,modificado_em as ModificadoEm
                ,ativo as Ativo
            from
                perfil
            order by nome
            limit {pagination.Limit()} offset {pagination.Offset()};
            select count(*) from perfil;
        ");

        var list = await query.ReadAsync<PerfilDto>();
        return new PaginatedList<PerfilDto>(list, pagination.SetTotal(await query.ReadFirstAsync<int>()));
    }

    public async Task<PaginatedList<PerfilDto>> FindAllAsync(Pagination pagination, Search search)
    {
        var query = await _db.QueryMultipleAsync($@"
            select
                uuid as Uuid
                ,nome as Nome
                ,criado_por as CriadoPor
                ,criado_em as CriadoEm
                ,modificado_por as ModificadoPor
                ,modificado_em as ModificadoEm
                ,ativo as Ativo
            from
                perfil
            where
                nome ilike :search
            order by nome
            limit {pagination.Limit()} offset {pagination.Offset()};
            select count(*) from perfil where nome ilike :search;
        ", new { search = search.ToString() });

        var list = await query.ReadAsync<PerfilDto>();
        return new PaginatedList<PerfilDto>(list, pagination.SetTotal(await query.ReadFirstAsync<int>()));
    }
}
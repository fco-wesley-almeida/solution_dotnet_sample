using System.Data;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;
using CorteAutomatico.Core.Modules.DispositivoMarca.Queries;
using Dapper;

namespace CorteAutomatico.Data.Queries;

public class DispositivoMarcaDb: IDispositivoMarcaDb 
{
    private readonly IDbConnection _db;
    
    public DispositivoMarcaDb(IDbConnection db)
    {
        _db = db;
    }
    public async Task<DispositivoMarcaDto?> FindByUuid(Guid uuid)
    {
        const string sql = @"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,tp.uuid as TipoDispositivoUuid
                ,tp.nome as TipoDispositivoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from
                dispositivo_marca dm
                join tipo_dispositivo tp on tp.id = dm.tipo_dispositivo_id
            where
                dm.ativo
                and dm.uuid = :uuid 
        ";
        var binds = new { uuid };
        return await _db.QueryFirstOrDefaultAsync<DispositivoMarcaDto>(sql, binds);
    }

    public async Task<IEnumerable<DispositivoMarcaDto>> FindAllAsync()
    {
        const string sql = @"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,tp.uuid as TipoDispositivoUuid
                ,tp.nome as TipoDispositivoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from
                dispositivo_marca dm
                join tipo_dispositivo tp on tp.id = dm.tipo_dispositivo_id
            where
                dm.ativo
        ";
        return await _db.QueryAsync<DispositivoMarcaDto>(sql);
    }

    public async Task<IEnumerable<DispositivoMarcaDto>> FindAllAsync(Search search)
    {
        const string sql = @"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,tp.uuid as TipoDispositivoUuid
                ,tp.nome as TipoDispositivoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from
                dispositivo_marca dm
                join tipo_dispositivo tp on tp.id = dm.tipo_dispositivo_id
            where
                dm.nome ilike :search
                and dm.ativo
        ";
        var binds = new { search = search.ToString() };
        return await _db.QueryAsync<DispositivoMarcaDto>(sql, binds);
    }

    public async Task<PaginatedList<DispositivoMarcaDto>> FindAllAsync(Pagination pagination)
    {
        var query = await _db.QueryMultipleAsync($@"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,tp.uuid as TipoDispositivoUuid
                ,tp.nome as TipoDispositivoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from
                dispositivo_marca dm
                join tipo_dispositivo tp on tp.id = dm.tipo_dispositivo_id
            where
                dm.ativo
            limit {pagination.Limit()} offset {pagination.Offset()};
            select count(*) from dispositivo_marca where ativo;
        ");

        var list = await query.ReadAsync<DispositivoMarcaDto>();
        return new PaginatedList<DispositivoMarcaDto>(list, pagination.SetTotal(await query.ReadFirstAsync<int>()));
    }

    public async Task<PaginatedList<DispositivoMarcaDto>> FindAllAsync(Pagination pagination, Search search)
    {
        var query = await _db.QueryMultipleAsync($@"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,tp.uuid as TipoDispositivoUuid
                ,tp.nome as TipoDispositivoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from
                dispositivo_marca dm
                join tipo_dispositivo tp on tp.id = dm.tipo_dispositivo_id
            where
                dm.ativo
                and dm.nome ilike :search
            limit {pagination.Limit()} offset {pagination.Offset()};
            select count(*) from dispositivo_marca where ativo and nome ilike :search;
        ", new { search = search.ToString() });

        var list = await query.ReadAsync<DispositivoMarcaDto>();
        return new PaginatedList<DispositivoMarcaDto>(list, pagination.SetTotal(await query.ReadFirstAsync<int>()));
    }

    public async Task<PaginatedList<DispositivoMarcaDto>> FindByTipoDispositivoUuidAsync(Pagination pagination, Guid tipoDispositivoUuid)
    {
        var query = await _db.QueryMultipleAsync($@"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,tp.uuid as TipoDispositivoUuid
                ,tp.nome as TipoDispositivoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from
                dispositivo_marca dm
                inner join tipo_dispositivo tp on tp.id = dm.tipo_dispositivo_id
            where
                tp.uuid = :tipoDispositivoUuid
            limit {pagination.Limit()} offset {pagination.Offset()};

            select 
                count(*) 
            from 
                dispositivo_marca dm 
                inner join tipo_dispositivo td on td.id = dm.tipo_dispositivo_id 
            where  td.uuid = :tipoDispositivoUuid;
        ", new { tipoDispositivoUuid  });
        var list = await query.ReadAsync<DispositivoMarcaDto>();
        return new PaginatedList<DispositivoMarcaDto>(list, pagination.SetTotal(await query.ReadFirstAsync<int>()));
    }

    public async Task<IEnumerable<DispositivoMarcaDto>> FindByTipoDispositivoUuidAsync(Guid tipoDispositivoUuid)
    {
        const string sql = @"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,td.uuid as TipoDispositivoUuid
                ,td.nome as TipoDispositivoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from
                dispositivo_marca dm
                join tipo_dispositivo td on td.id = dm.tipo_dispositivo_id
            where
                td.uuid = :tipoDispositivoUuid
        ";
        var binds = new { tipoDispositivoUuid };
        return await _db.QueryAsync<DispositivoMarcaDto>(sql, binds);
    }
}
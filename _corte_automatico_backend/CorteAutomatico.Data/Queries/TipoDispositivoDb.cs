using System.Data;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Queries;
using Dapper;

namespace CorteAutomatico.Data.Queries;

public class TipoDispositivoDb: ITipoDispositivoDb
{
    private readonly IDbConnection _db;

    public TipoDispositivoDb(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<TipoDispositivoDto>> FindAllAsync()
    {
        const string sql = @"
            select
	            uuid as Uuid,
	            nome as Nome,
	            criado_por as CriadoPor,
	            criado_em as CriadoEm,
	            modificado_por as ModificadoPor,
	            modificado_em as ModificadoEm,
	            ativo as Ativo
            from
	            tipo_dispositivo
			order by nome
        ";
        return await _db.QueryAsync<TipoDispositivoDto>(sql);
    }

    public async Task<IEnumerable<TipoDispositivoDto>> FindAllAsync(Search search)
    {
        const string sql = @"
            select
	            uuid as Uuid,
	            nome as Nome,
	            criado_por as CriadoPor,
	            criado_em as CriadoEm,
	            modificado_por as ModificadoPor,
	            modificado_em as ModificadoEm,
	            ativo as Ativo
            from
	            tipo_dispositivo
			where
			    nome ilike :search
			order by nome
        ";
        var binds = new { search = search.ToString()};
        return await _db.QueryAsync<TipoDispositivoDto>(sql, binds);
    }

    public async Task<TipoDispositivoDto?> FindByUuidAsync(Guid uuid)
    {
	    const string sql = @"
            select
	            uuid as Uuid,
	            nome as Nome,
	            criado_por as CriadoPor,
	            criado_em as CriadoEm,
	            modificado_por as ModificadoPor,
	            modificado_em as ModificadoEm,
	            ativo as Ativo
            from
	            tipo_dispositivo
			where
			    uuid = :uuid
        ";
	    var binds = new { uuid };
	    return await _db.QueryFirstOrDefaultAsync<TipoDispositivoDto>(sql, binds);
    }

    public async Task<PaginatedList<TipoDispositivoDto>> FindAllAsync(Pagination pagination)
    {
	    var query = await _db.QueryMultipleAsync($@"
            select
	            uuid as Uuid,
	            nome as Nome,
	            criado_por as CriadoPor,
	            criado_em as CriadoEm,
	            modificado_por as ModificadoPor,
	            modificado_em as ModificadoEm,
	            ativo as Ativo
            from
	            tipo_dispositivo
			order by nome
	    	limit {pagination.Limit()} offset {pagination.Offset()};

			select count(*) from tipo_dispositivo;
        ");
	    var list = await query.ReadAsync<TipoDispositivoDto>();
	    return new(
		    list, 
		    pagination.SetTotal(await query.ReadFirstAsync<int>())
		);
    }

    public async Task<PaginatedList<TipoDispositivoDto>> FindAllAsync(Pagination pagination, Search search)
    {
	    var query = await _db.QueryMultipleAsync($@"
            select
	            uuid as Uuid,
	            nome as Nome,
	            criado_por as CriadoPor,
	            criado_em as CriadoEm,
	            modificado_por as ModificadoPor,
	            modificado_em as ModificadoEm,
	            ativo as Ativo
            from
	            tipo_dispositivo
			where 
				nome ilike :search
			order by nome
			limit {pagination.Limit()} offset {pagination.Offset()};
			    
			select count(*) from tipo_dispositivo where nome ilike :search;
        ", new { search = search.ToString() });
	    var list = await query.ReadAsync<TipoDispositivoDto>();
	    return new(
		    list, 
		    pagination.SetTotal(await query.ReadFirstAsync<int>())
	    );
    }
}
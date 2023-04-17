using System.Data;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;
using CorteAutomatico.Core.Modules.DispositivoModelo.Queries;
using Dapper;

namespace CorteAutomatico.Data.Queries;

public class DispositivoModeloDb : IDispositivoModeloDb
{
    private readonly IDbConnection _db;

    public DispositivoModeloDb(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<DispositivoModeloDto>> FindAllAsync()
    {
        const string sql = @"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,dm.compativel as Compativel
                ,dm.quantidade_fases as QuantidadeFases
                ,dma.uuid as DispositivoMarcaUuid
                ,dma.nome as DispositivoMarcaNome
                ,tp.uuid as DispositivoTipoUuid
                ,tp.nome as DispositivoTipoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from dispositivo_modelo dm
            join dispositivo_marca dma on dma.id = dm.dispositivo_marca_id
            join tipo_dispositivo tp on tp.id = dma.tipo_dispositivo_id
            where dm.ativo
        ";

        return await _db.QueryAsync<DispositivoModeloDto>(sql);
    }

    public async Task<IEnumerable<DispositivoModeloDto>> FindAllAsync(Search search)
    {
        const string sql = @"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,dm.compativel as Compativel
                ,dm.quantidade_fases as QuantidadeFases
                ,dma.uuid as DispositivoMarcaUuid
                ,dma.nome as DispositivoMarcaNome
                ,tp.uuid as DispositivoTipoUuid
                ,tp.nome as DispositivoTipoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from dispositivo_modelo dm
            join dispositivo_marca dma on dma.id = dm.dispositivo_marca_id
            join tipo_dispositivo tp on tp.id = dma.tipo_dispositivo_id
            where 
                dm.ativo
                and dm.nome ilike :search 
        ";
        var binds = new { search = search.ToString() };
        return await _db.QueryAsync<DispositivoModeloDto>(sql, binds);
    }

    public async Task<PaginatedList<DispositivoModeloDto>> FindAllAsync(Pagination pagination)
    {
        var query = await _db.QueryMultipleAsync($@"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,dm.compativel as Compativel
                ,dm.quantidade_fases as QuantidadeFases
                ,dma.uuid as DispositivoMarcaUuid
                ,dma.nome as DispositivoMarcaNome
                ,tp.uuid as DispositivoTipoUuid
                ,tp.nome as DispositivoTipoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from dispositivo_modelo dm
            join dispositivo_marca dma on dma.id = dm.dispositivo_marca_id
            join tipo_dispositivo tp on tp.id = dma.tipo_dispositivo_id
            where dm.ativo
            limit {pagination.Limit()} offset {pagination.Offset()};
            select count(*) from dispositivo_modelo dm where dm.ativo;
        ");
        var list = await query.ReadAsync<DispositivoModeloDto>();
        return new PaginatedList<DispositivoModeloDto>(list, pagination.SetTotal(await query.ReadSingleAsync<int>()));
    }

    public async Task<PaginatedList<DispositivoModeloDto>> FindAllAsync(Pagination pagination, Search search)
    {
        var query = await _db.QueryMultipleAsync($@"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,dm.compativel as Compativel
                ,dm.quantidade_fases as QuantidadeFases
                ,dma.uuid as DispositivoMarcaUuid
                ,dma.nome as DispositivoMarcaNome
                ,tp.uuid as DispositivoTipoUuid
                ,tp.nome as DispositivoTipoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from dispositivo_modelo dm
            join dispositivo_marca dma on dma.id = dm.dispositivo_marca_id
            join tipo_dispositivo tp on tp.id = dma.tipo_dispositivo_id
            where dm.ativo and dm.nome ilike :search
            limit {pagination.Limit()} offset {pagination.Offset()};
            select count(*) from dispositivo_modelo dm where dm.ativo and dm.nome ilike :search;
        ", new { search = search.ToString() });
        var list = await query.ReadAsync<DispositivoModeloDto>();
        return new PaginatedList<DispositivoModeloDto>(list, pagination.SetTotal(await query.ReadSingleAsync<int>()));
    }

    public async Task<DispositivoModeloDto?> FindByUuid(Guid uuid)
    {
        const string sql = @"
            select
                dm.uuid as Uuid
                ,dm.nome as Nome
                ,dm.compativel as Compativel
                ,dm.quantidade_fases as QuantidadeFases
                ,dma.uuid as DispositivoMarcaUuid
                ,dma.nome as DispositivoMarcaNome
                ,tp.uuid as DispositivoTipoUuid
                ,tp.nome as DispositivoTipoNome
                ,dm.criado_por as CriadoPor
                ,dm.criado_em as CriadoEm
                ,dm.modificado_por as ModificadoPor
                ,dm.modificado_em as ModificadoEm
                ,dm.ativo as Ativo
            from dispositivo_modelo dm
            join dispositivo_marca dma on dma.id = dm.dispositivo_marca_id
            join tipo_dispositivo tp on tp.id = dma.tipo_dispositivo_id
            where dm.ativo and dm.uuid = :uuid
        ";
        var binds = new { uuid };
        return await _db.QueryFirstOrDefaultAsync<DispositivoModeloDto>(sql, binds);
    }
}
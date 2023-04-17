using System.Data;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.Authentication.Dtos;
using CorteAutomatico.Core.Modules.Authentication.Queries;
using CorteAutomatico.Core.Modules.Usuario.Dtos;
using Dapper;
namespace CorteAutomatico.Data.Queries;

public class UsuarioDb: IUsuarioDb
{
    private readonly IDbConnection _db;

    public UsuarioDb(IDbConnection db) => _db = db;

    public async Task<UsuarioWithPasswdDto?> FindByLoginAsync(string login)
    {
        const string sql = @"
			select
				u.id as Id
				,u.uuid as Uuid
				,u.login as Login
				,us.senha as Senha
				,u.perfil_id as PerfilId
				,us.data_expiracao as DataExpiracaoSenha
			from usuario u
			inner join usuario_senha us on us.usuario_id = u.id
			where
				u.login = :login
			order by us.data_expiracao desc
        ";
        return await _db.QueryFirstOrDefaultAsync<UsuarioWithPasswdDto>(sql, new { login });
    }

    public async Task<UsuarioWithPasswdDto?> FindByIdAsync(int usuarioId)
    {
	    const string sql = @"
			select
				u.id as Id
				,u.uuid as Uuid
				,u.login as Login
				,us.senha as Senha
				,u.perfil_id as PerfilId
				,us.data_expiracao as DataExpiracaoSenha
			from usuario u
			inner join usuario_senha us on us.usuario_id = u.id
			where
				u.id = :usuarioId
			order by us.data_expiracao desc
        ";
	    return await _db.QueryFirstOrDefaultAsync<UsuarioWithPasswdDto>(sql, new { usuarioId });
    }

    public async Task<IEnumerable<UsuarioDto>> FindAllAsync()
    {
        const string sql = @"
			SELECT
				u.uuid AS Uuid
				,u.nome AS Nome
				,u.cpf AS Cpf
				,u.email AS Email
				,u.login AS Login
				,p.uuid  AS PerfilUuid
				,p.nome AS PerfilNome
				,u.email_confirmado AS EmailConfirmado
				,u.criado_por AS CriadoPor
				,u.criado_em AS CriadoEm
				,u.modificado_por AS ModificadoPor
				,u.modificado_em AS ModificadoEm
				,u.ativo AS Ativo
			FROM
				usuario u
				INNER JOIN perfil p ON u.perfil_id = p.id
			ORDER BY u.nome
        ";
        return await _db.QueryAsync<UsuarioDto>(sql);
    }

    public async Task<IEnumerable<UsuarioDto>> FindAllAsync(Search search)
    {
        const string sql = @"
			SELECT
				u.uuid AS Uuid
				,u.nome AS Nome
				,u.cpf AS Cpf
				,u.email AS Email
				,u.login AS Login
				,p.uuid  AS PerfilUuid
				,p.nome AS PerfilNome
				,u.email_confirmado AS EmailConfirmado
				,u.criado_por AS CriadoPor
				,u.criado_em AS CriadoEm
				,u.modificado_por AS ModificadoPor
				,u.modificado_em AS ModificadoEm
				,u.ativo AS Ativo
			FROM
				usuario u
				INNER JOIN perfil p ON u.perfil_id = p.id
			WHERE
			    (
			        u.nome ilike :search
			        or u.cpf ilike :search
			        or u.email ilike :search
			        or u.login ilike :search
			    )
			ORDER BY u.nome
        ";
        var binds = new { search = search.ToString()};
        return await _db.QueryAsync<UsuarioDto>(sql, binds);
    }

    public async Task<UsuarioDto?> FindByUuid(Guid uuid)
    {
	    const string sql = $@"
			SELECT
				u.uuid AS Uuid
				,u.nome AS Nome
				,u.cpf AS Cpf
				,u.email AS Email
				,u.login AS Login
				,p.uuid  AS PerfilUuid
				,p.nome AS PerfilNome
				,u.email_confirmado AS EmailConfirmado
				,u.criado_por AS CriadoPor
				,u.criado_em AS CriadoEm
				,u.modificado_por AS ModificadoPor
				,u.modificado_em AS ModificadoEm
				,u.ativo AS Ativo
			FROM
				usuario u
				INNER JOIN perfil p ON u.perfil_id = p.id
			WHERE 
				u.uuid = :uuid
        ";
	    var binds = new { uuid };
	    return await _db.QueryFirstOrDefaultAsync<UsuarioDto>(sql, binds);
    }

    public async Task<PaginatedList<UsuarioDto>> FindAllAsync(Pagination pagination)
    {
	    var query = await _db.QueryMultipleAsync($@"
			SELECT
				u.uuid AS Uuid
				,u.nome AS Nome
				,u.cpf AS Cpf
				,u.email AS Email
				,u.login AS Login
				,p.uuid  AS PerfilUuid
				,p.nome AS PerfilNome
				,u.email_confirmado AS EmailConfirmado
				,u.criado_por AS CriadoPor
				,u.criado_em AS CriadoEm
				,u.modificado_por AS ModificadoPor
				,u.modificado_em AS ModificadoEm
				,u.ativo AS Ativo
			FROM
				usuario u
				INNER JOIN perfil p ON u.perfil_id = p.id	
			ORDER BY u.nome
			LIMIT {pagination.Limit()} OFFSET {pagination.Offset()};

			SELECT count(*) FROM usuario;
        ");
	    var list = await query.ReadAsync<UsuarioDto>();
	    return new(
		    list, 
		    pagination.SetTotal(await query.ReadFirstAsync<int>())
		);
    }

    public async Task<PaginatedList<UsuarioDto>> FindAllAsync(Pagination pagination, Search search)
    {
	    var query = await _db.QueryMultipleAsync($@"
			SELECT
				u.uuid AS Uuid
				,u.nome AS Nome
				,u.cpf AS Cpf
				,u.email AS Email
				,u.login AS Login
				,p.uuid  AS PerfilUuid
				,p.nome AS PerfilNome
				,u.email_confirmado AS EmailConfirmado
				,u.criado_por AS CriadoPor
				,u.criado_em AS CriadoEm
				,u.modificado_por AS ModificadoPor
				,u.modificado_em AS ModificadoEm
				,u.ativo AS Ativo
			FROM
				usuario u
				INNER JOIN perfil p ON u.perfil_id = p.id		
			WHERE 
			    (
			        u.nome ilike :search
			        or u.cpf ilike :search
			        or u.email ilike :search
			        or u.login ilike :search
			    )
			ORDER BY u.nome
			LIMIT {pagination.Limit()} OFFSET {pagination.Offset()};

			SELECT 
			    count(*) 
			FROM 
			    usuario u
				INNER JOIN perfil p ON u.perfil_id = p.id		
			WHERE 
			    (
			        u.nome ILIKE :search
			        OR u.cpf ILIKE :search
			        OR u.email ILIKE :search
			        OR u.login ILIKE :search
			    );
        ", new { search = search.ToString() });
	    var list = await query.ReadAsync<UsuarioDto>();
	    return new(
		    list, 
		    pagination.SetTotal(await query.ReadFirstAsync<int>())
	    );
    }

    public async Task<bool> ExistsWithSameLoginAsync(string login)
    {
	    var query = await _db.QueryAsync<int>(@"
			SELECT 
				1 
			WHERE 
				EXISTS (SELECT 1 FROM usuario WHERE login = :login and ativo)
		", new { login });
	    return query.Any();
    }

    public async Task<bool> ExistsWithSameEmailAsync(string email)
    {
	    var query = await _db.QueryAsync<int>(@"
			SELECT 
				1 
			WHERE 
				EXISTS (SELECT 1 FROM usuario WHERE email = :email and ativo)
		", new { email });
	    return query.Any();
    }

    public async Task<bool> ExistsWithSameCpfAsync(string cpf)
    {
	    var query = await _db.QueryAsync<int>(@"
			SELECT 
				1 
			WHERE 
				EXISTS (SELECT 1 FROM usuario WHERE cpf = :cpf and ativo)
		", new { cpf });
	    return query.Any();
    }
}
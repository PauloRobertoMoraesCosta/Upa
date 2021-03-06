﻿using System;
using System.Collections.Generic;
using System.Linq;
using Upa.Dados.Verifications;
using Upa.Dominio.Entidades;
using Upa.Dominio.Interfaces.Repositorios;

namespace Upa.Dados.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public Usuario logaUsuario(String login, String senha)
        {
            string loginLimpo = VerificacoesBanco.LimpaCaracteresEspeciais(login);
            string senhaLimpa = VerificacoesBanco.LimpaCaracteresEspeciais(senha);
            Usuario usuarioBanco;
            
            try
            {
                usuarioBanco = db.Usuarios.AsNoTracking().FirstOrDefault(u => u.Login.Equals(loginLimpo) && u.Ativo.Equals("True"));
                if (usuarioBanco == null)
                    throw new DadosException("Usuario não cadastrado ou desativado!");

                usuarioBanco = db.Usuarios.AsNoTracking().FirstOrDefault(u => u.Login.Equals(loginLimpo) && u.Senha.Equals(senhaLimpa) && u.Ativo.Equals("True"));
                if (usuarioBanco == null)
                    throw new DadosException("Senha Inválida!");
                    
                return usuarioBanco;
            }
            catch (DadosException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Problema inesperado ao fazer login no banco! " + ex.Message);
            }
        }


        public IEnumerable<Usuario> RetornausuariosAtivosAsNoTracking()
        {
            try
            {
                IEnumerable<Usuario> usuariosAtivos =
                    (IEnumerable<Usuario>) db.Usuarios.AsNoTracking().Where(u => u.Ativo.Equals("True"));
                if (usuariosAtivos == null)
                    throw new DadosException("Nenhum Usuário ativo no sistema");
                return usuariosAtivos;
            }
            catch (DadosException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Problema inesperado ao carregar usuários ativos! " + ex.Message);
            }
        }
    }
}


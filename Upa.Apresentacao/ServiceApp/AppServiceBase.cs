﻿using System;
using System.Collections.Generic;
using Upa.Apresentacao.InterfacesApp;
using Upa.Dominio.Interfaces.Servicos;

namespace Upa.Apresentacao.ServiceApp
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _serviceBase;

        public AppServiceBase(IServicoBase<TEntity> servicoBase)
        {
            _serviceBase = servicoBase;
        }

        public void Adiciona(TEntity objeto)
        {
            _serviceBase.Adiciona(objeto);   
        }

        public TEntity RetornaPorId(int Id)
        {
            return _serviceBase.RetornaPorId(Id);
        }

        public IEnumerable<TEntity> RetornaTodos()
        {
            return _serviceBase.RetornaTodos();
        }

        public IEnumerable<TEntity> RetornaTodosAsNoTracking()
        {
            return _serviceBase.RetornaTodosAsNoTracking();
        }

        public void Alterar(TEntity objeto)
        {
            _serviceBase.Alterar(objeto);
        }

        public void Remover(TEntity objeto)
        {
            _serviceBase.Remover(objeto);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}

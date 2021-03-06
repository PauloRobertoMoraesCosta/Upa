﻿using System.Collections.Generic;

namespace Upa.Apresentacao.InterfacesApp
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Adiciona(TEntity objeto);
        TEntity RetornaPorId(int Id);
        IEnumerable<TEntity> RetornaTodos();
        IEnumerable<TEntity> RetornaTodosAsNoTracking();
        void Alterar(TEntity objeto);
        void Remover(TEntity objeto);
        void Dispose();
    }
}

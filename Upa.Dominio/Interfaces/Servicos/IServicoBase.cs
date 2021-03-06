﻿using System.Collections.Generic;

namespace Upa.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class 
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.DB.Interfaces
{
    public interface IDBComandosBasicosEntidade<T>
    {
        T Inserir(T obj);
        T BuscarPeloID(int id);
        List<T> BuscarTodos();
        T Atualizar(T obj);
        bool Deletar(T obj);

    }
}

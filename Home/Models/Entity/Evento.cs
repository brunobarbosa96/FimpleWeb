﻿using System;
using System.Collections.Generic;

namespace Home.Models.Entity
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public Entidade Entidade { get; set; }
        public Categoria Categoria { get; set; }
        public Curso Curso { get; set; }
        public IEnumerable<Usuario> Participantes { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
    }
}
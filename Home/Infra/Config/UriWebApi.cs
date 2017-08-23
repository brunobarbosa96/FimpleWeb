﻿using System.Diagnostics;

namespace Home.Infra.Config
{
    public static class UriWebApi
    {
        private static string Server => "http://fimpleapi.azurewebsites.net/";
        public static string Login => $"{Server}api/authentication/login/";
        public static string Usuario => $"{Server}api/usuario/";
        public static string Curso => $"{Server}api/curso/";
        public static string Chat => $"{Server}api/chat/";
        public static string Publicacao => $"{Server}api/timeline/publicacao/";
        public static string Evento => $"{Server}api/evento/";
        public static string Notificacao => $"{Server}api/notificacao/";
    }
}

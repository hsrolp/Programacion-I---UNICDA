// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

using System.Collections.Generic;
using VideoFormulario.Modelo;

namespace VideoFormulario.Datos
{
    public class Usuario
    {
        private List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

        public void Guardar(UsuarioModel modelo)
        {
            listaUsuarios.Add(modelo);
        }

        public List<UsuarioModel> Consultar()
        {
            return listaUsuarios;
        }

        public void Limpiar()
        {
            listaUsuarios.Clear();
        }
    }
}

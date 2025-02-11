﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Citas
{
    public class ClientesBL
    {
        Contexto _contexto;

        public BindingList<Cliente> ListaClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListaClientes = new BindingList<Cliente>();
        }

        public BindingList<Cliente> ObtenerClientes()
        {
            _contexto.Clientes.Load();
            ListaClientes = _contexto.Clientes.Local.ToBindingList();

            return ListaClientes;
        }

        // CANCELAR
        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarCliente(Cliente cliente)
        {
            var resultado = Validar(cliente);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();
            _contexto.Clientes.Add(nuevoCliente);
        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaClientes.ToList())
            {
                if (cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Cliente cliente)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            // Agregando anulacion de factura.//
            if (cliente == null)
            {
                resultado.Mensaje = "Ingrese un cliente valido.";
                resultado.Exitoso = false;

                return resultado;
            }

            if (cliente == null)
            {
                resultado.Mensaje = "Agregue un cliente valido";
                resultado.Exitoso = false;

                return resultado;
            }

            if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese el nombre del cliente";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Telefono) == true)
            {
                resultado.Mensaje = "Ingrese el numero celular del cliente.";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Direccion) == true)
            {
                resultado.Mensaje = "Ingrese la direccion del cliente.";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Email) == true)
            {
                resultado.Mensaje = "Ingrese el correo del cliente.";
                resultado.Exitoso = false;
            }
            return resultado;
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        public Cliente()
        {
            Activo = true;
        }
    }
}
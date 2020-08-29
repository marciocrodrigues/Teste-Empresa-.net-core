using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces;
using TesteBitzen.DOMAIN.Interfaces.Usuarios;

namespace TesteBitzen.DOMAIN.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IRetorno Alterar(Guid id, UsuarioDTO dto)
        {
            dto.Validate();

            if (dto.Invalid)
            {
                return new RetornoDTO(false, "Erro na Requisição, verificar valores enviados", dto.Notifications);
            }

            var usuario = _repository.BuscarPorId(id);
            usuario.AlterarEmail(dto.Email);
            usuario.AlterarSenha(dto.Senha);
            usuario.AlterarNome(dto.Nome);

            if (!_repository.Alterar(usuario))
            {
                return new RetornoDTO(false, "Erro ao tentar alterar o usuario", null);
            }

            return new RetornoDTO(true, "Usuário alterador com sucesso", usuario);
        }

        public IRetorno BuscarPorEmailSenha(LoginDTO dto)
        {
            dto.Validate();

            if (dto.Invalid)
            {
                return new RetornoDTO(false, "Erro na Requisição, verificar valores enviado", dto.Notifications);
            }

            var usuario = _repository.BuscarPorEmailSenha(dto.Email, dto.Senha);

            if(usuario == null)
            {
                return new RetornoDTO(false, "Nenhum usuário encontrado", null);
            }

            return new RetornoDTO(true, "", usuario);
        }

        public IRetorno BuscarPorId(Guid id)
        {
            var usuario = _repository.BuscarPorId(id);

            if (usuario == null)
            {
                return new RetornoDTO(false, "Nenhum usuário encontrado", null);
            }

            return new RetornoDTO(true, "", usuario);
        }

        public IRetorno BuscarTodos()
        {
            var usuarios = _repository.BuscarTodos();

            if(usuarios.ToList().Count > 0)
            {
                return new RetornoDTO(true, "", usuarios);
            }

            return new RetornoDTO(false, "", null);
        }

        public IRetorno Criar(UsuarioDTO dto)
        {
            dto.Validate();

            if (dto.Invalid)
            {
                return new RetornoDTO(false, "Erro na Requisição, verificar valores enviado", dto.Notifications);
            }

            var usuario = new Usuario(dto.Email, dto.Senha, dto.Nome);

            if (!_repository.Criar(usuario))
            {
                return new RetornoDTO(false, "Erro ao tentar criar usuário", null);
            }

            return new RetornoDTO(true, "Usuário criado com sucesso", usuario);

        }

        public IRetorno Excluir(Guid id)
        {
            var usuario = _repository.BuscarPorId(id);

            if(usuario == null)
            {
                return new RetornoDTO(false, "Usuário não encontrado para exclusão", null);
            }

            if (!_repository.Excluir(usuario))
            {
                return new RetornoDTO(false, "Erro tentar excluir usuário", null);
            }

            return new RetornoDTO(true, "Usuário removido com sucesso", null);
        }
    }
}

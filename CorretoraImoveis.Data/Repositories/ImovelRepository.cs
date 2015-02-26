using CorretoraImoveis.Data.ContextDb;
using CorretoraImoveis.Domain.Contracts.Repositories;
using CorretoraImoveis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace CorretoraImoveis.Data.Repositories
{
    public class ImovelRepository:DbContext, IImovelRepository
    {
        public void Save(Imovel entity)
        {
            if (entity.Id > 0)
                UpDate(entity);
            else
                Add(entity);       
        }

        private void Add(Imovel entity)
        {
            try
            {
                ClearParameters();
                AddParameters("@Descricao", entity.Descricao);
                AddParameters("@Valor", entity.Valor);
                AddParameters("@UrlFoto",entity.UrlFoto);
                ExecCommand(CommandType.StoredProcedure, "uspImovelInserir");
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }

        private void UpDate(Imovel entity)
        {
            try
            {
                ClearParameters();
                AddParameters("@Id", entity.Id);
                AddParameters("@Descricao", entity.Descricao);
                AddParameters("@Valor", entity.Valor);
                AddParameters("@UrlFoto", entity.UrlFoto);
                ExecCommand(CommandType.StoredProcedure, "uspImovelAlterar");
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }

        public void Delete(Imovel entity)
        {
            try
            {
                ClearParameters();
                AddParameters("@Id",entity.Id);
                ExecCommand(CommandType.StoredProcedure, "uspImovelExcluir");
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }

        public Imovel GetById (int id)
        {
            try
            {
                ClearParameters();
                AddParameters("@Id",id);
                var dr = ExecQuery(CommandType.StoredProcedure, "uspImovelListarId");
                Imovel imovel = null;
                using (dr)
                {
                    while (dr.Read())
                    {
                        imovel = new Imovel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Descricao = dr["Descricao"].ToString(),
                            Valor = Convert.ToDecimal(dr["Valor"]),
                            UrlFoto = dr["UrlFoto"].ToString(),
                            DataCadastro = Convert.ToDateTime(dr["DataCadastro"]),
                            Ativo = Convert.ToBoolean(dr["Ativo"])
                        };
                    }
                }
                
                return imovel;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Imovel> GetAll()
        {
            try
            {
                var dr = ExecQuery(CommandType.StoredProcedure, "uspImovelListarTodos");
                var imoveis = new List<Imovel>();
                using (dr)
                {
                    while (dr.Read())
                    {
                        var imovel = new Imovel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Descricao = dr["Descricao"].ToString(),
                            Valor = Convert.ToDecimal(dr["Valor"]),
                            UrlFoto = dr["UrlFoto"].ToString(),
                            DataCadastro = Convert.ToDateTime(dr["DataCadastro"]),
                            Ativo = Convert.ToBoolean(dr["Ativo"])
                        };

                        imoveis.Add(imovel);
                    }

                    return imoveis;
                }               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Commit()
        {
           ExecCommit();
        }
    }
}

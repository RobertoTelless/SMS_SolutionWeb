﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntitiesServices.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SMS_DatabaseEntities : DbContext
    {
        public SMS_DatabaseEntities()
            : base("name=SMS_DatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ASSINANTE> ASSINANTE { get; set; }
        public virtual DbSet<CATEGORIA_NOTIFICACAO> CATEGORIA_NOTIFICACAO { get; set; }
        public virtual DbSet<CONFIGURACAO> CONFIGURACAO { get; set; }
        public virtual DbSet<LOG> LOG { get; set; }
        public virtual DbSet<NOTIFICACAO> NOTIFICACAO { get; set; }
        public virtual DbSet<NOTIFICACAO_ANEXO> NOTIFICACAO_ANEXO { get; set; }
        public virtual DbSet<PAIS> PAIS { get; set; }
        public virtual DbSet<PERFIL> PERFIL { get; set; }
        public virtual DbSet<UF> UF { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<USUARIO_ANEXO> USUARIO_ANEXO { get; set; }
        public virtual DbSet<NOTICIA> NOTICIA { get; set; }
        public virtual DbSet<NOTICIA_COMENTARIO> NOTICIA_COMENTARIO { get; set; }
        public virtual DbSet<ASSINANTE_ANEXO> ASSINANTE_ANEXO { get; set; }
        public virtual DbSet<CAMPANHA> CAMPANHA { get; set; }
        public virtual DbSet<CAMPANHA_CONTATO> CAMPANHA_CONTATO { get; set; }
        public virtual DbSet<CATEGORIA_CONTATO> CATEGORIA_CONTATO { get; set; }
        public virtual DbSet<CLUBE> CLUBE { get; set; }
        public virtual DbSet<CONTATO> CONTATO { get; set; }
        public virtual DbSet<ORIGEM> ORIGEM { get; set; }
        public virtual DbSet<PROFISSAO> PROFISSAO { get; set; }
        public virtual DbSet<TEMPLATE> TEMPLATE { get; set; }
        public virtual DbSet<TEMPLATE_EMAIL> TEMPLATE_EMAIL { get; set; }
        public virtual DbSet<GRUPO> GRUPO { get; set; }
        public virtual DbSet<GRUPO_CONTATO> GRUPO_CONTATO { get; set; }
        public virtual DbSet<CAMPANHA_GRUPO> CAMPANHA_GRUPO { get; set; }
        public virtual DbSet<MENSAGEM> MENSAGEM { get; set; }
        public virtual DbSet<MENSAGEM_CAMPANHA> MENSAGEM_CAMPANHA { get; set; }
        public virtual DbSet<MENSAGEM_CONTATO> MENSAGEM_CONTATO { get; set; }
        public virtual DbSet<MENSAGEM_GRUPO> MENSAGEM_GRUPO { get; set; }
        public virtual DbSet<MENSAGEM_ANEXO> MENSAGEM_ANEXO { get; set; }
    }
}

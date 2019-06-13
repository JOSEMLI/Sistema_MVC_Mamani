namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    using System.Data.Entity.Validation;
    using System.Web;
    using System.IO;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        public int docente_id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string clave { get; set; }

        [Required]
        [StringLength(20)]
        public string nivel { get; set; }

        [StringLength(250)]
        public string avatar { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Docente Docente { get; set; }




        //metodo listar

        public List<Usuario> listar() //retorna una coleccion de resgistro
        {
            var objusuario = new List<Usuario>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objusuario = db.Usuario.Include("docente").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objusuario;
        }

        //metodo obtener

        public Usuario obtener(int id) //retorna solo un objeto
        {
            var objusuario = new Usuario();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objusuario = db.Usuario.Include("docente").Where(x => x.usuario_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objusuario;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.usuario_id > 0)
                    {
                        //si existe un valor mayor a cero es porque exiiste el registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    {
                        //si no existe el registro lo graba(nuevo)
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //metodo eliminar

        public void eliminar()
        {
            try
            {
                using (var db = new modelo_sistemas())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        //metodo validar login

        public ResponseModel validarlogin(string Usuario, string Password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new modelo_sistemas())
                {
                    Password = HashHelper.MD5(Password);
                    var usuario = db.Usuario.Where(x => x.nombre == Usuario)
                                            .Where(x => x.clave == Password)
                                            .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.usuario_id.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuaro y/o password son incorrectos ....");
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }


        //metodo guardar perfil

        public ResponseModel guardarperfil(HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;

                    var usu = db.Entry(this);
                    usu.State = EntityState.Modified; //permite modificar el usuario

                    if (foto != null)
                    {
                        string extension = Path.GetExtension(foto.FileName).ToLower(); //el path me permite obtener algunas propiedades del archivo

                        int size = 1024 * 1014 * 5; //es el tamaño que recibe 
                        var filtroextension = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var extensiones = Path.GetExtension(foto.FileName); //la foto

                        if (filtroextension.Contains(extensiones) && (foto.ContentLength <= size))
                        {
                            string archivo = Path.GetFileName(foto.FileName);//es lo que vamos a obtener

                            //la ruta doonde guardaremos las imagenes
                            foto.SaveAs(HttpContext.Current.Server.MapPath("~/fotousu/" + archivo));
                            this.avatar = archivo;

                        }

                    }
                    else usu.Property(x => x.avatar).IsModified = false;

                    if (this.usuario_id == 0) usu.Property(x => x.usuario_id).IsModified = false;
                    if (this.docente_id == 0) usu.Property(x => x.docente_id).IsModified = false;
                    if (this.nombre == null) usu.Property(x => x.nombre).IsModified = false;
                    if (this.clave == null) usu.Property(x => x.clave).IsModified = false;
                    if (this.nivel == null) usu.Property(x => x.nivel).IsModified = false;
                    if (this.estado == null) usu.Property(x => x.estado).IsModified = false;

                    db.SaveChanges();
                    rm.SetResponse(true);

                }
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }





    }
}

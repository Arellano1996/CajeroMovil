
using CajeroMovil.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace CajeroMovil.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class historialViewModel
    {
        //Tiene todos los articulos de la base de datos SQL
        public List<articuloBaseDatos> articulos { get; set; }
        //Nos ayudara a separar en grupos los items que están en la base de datos los cuales
        //estan en articulos
        public List<articuloBaseDatos> listaAuxiliar { get; set; }
        //Una vez separados en grupo se agregaran a esta lista que servira como para el binding
        public ObservableCollection<listaArticulos> listaarticulos { get; set; }
        public historialViewModel()
        {
            //Actializa nuestra variable listaarticulos para poder hacer binding de los datos
            //y pintar la información
            Refresh();
        }

        public void Refresh()
        {
            //Inicializamos todo sin ningun dato
            articulos = new List<articuloBaseDatos>();
            listaAuxiliar = new List<articuloBaseDatos>();
            listaarticulos = new ObservableCollection<listaArticulos>();
            //Recuperamos los datos SQL en nuestr variable
            articulos = App.cr.GetAll();
            //Separamos en grupos los datos de articulos y los pondremos en listaarticulos que ya contiene
            //todos los datos pero ordenados en grupos
            formatearLista();
            Console.WriteLine("-------Proceso terminado");
        }
        public void formatearLista()
        {
            //Si articulos no cargo ningun dato del SQL regresar
            if (articulos.Count == 0) return;
            DateTime aux;
            bool mismoGrupo = true;
            //Tomamos una referencia del 1er item para compararlo con los
            //siguientes items, si tienen la misma fecha, pertenencen al mismo grupo
            //de lo contrario se creará otro grupo de items con la fecha correspondiente
            aux = articulos[0].fecha;
            //Recorremos la lista articulos que carga toda la base de datos
            foreach (var a in articulos)
            {
                //Si las fechas son diferentes tenemos un item de un grupo distinto
                //por lo tanto mismo grupo es falso
                if (a.fecha != aux) mismoGrupo = false;
                //Si el el item es del mismo grupo sigue agregando al grupo actual
                if (mismoGrupo) listaAuxiliar.Add(a);
                else
                {
                    float Total = 0;
                    foreach (var b in listaAuxiliar) Total += b.precio;
                    //Si el grupo es distinto crear el grupo con la fecha correspondiente y los
                    //items que se fueron agregando pertenecientes al mismo grupo
                    listaarticulos.Add(new listaArticulos(aux, Total, listaAuxiliar));
                    //Una vez se agregó el grupo establece la nueva referencia con el item
                    //actual que es el primer item del nuevo grupo
                    aux = a.fecha;
                    //Limpia el grupo anterior ya que ya ha sido agregado al binding
                    listaAuxiliar.Clear();
                    //Agrega el primer item del nuevo grupo recien creado
                    listaAuxiliar.Add(a);
                    //mismoGrupo vuelve a ser verdadero
                    mismoGrupo = true;
                }

            }
            //Al final del foreach no hay forma de agregar el último grupo con el que se estuvo trabajando
            //este último grupo no ha sido agregado y la lista ya ha sido recorrido por lo tanto la lista
            //actual contiene el último grupo, finalmente se agrega la binding
            float total = 0;
            foreach (var b in listaAuxiliar) total += b.precio;
            listaarticulos.Add(new listaArticulos(aux, total, listaAuxiliar));
        }





    }

}


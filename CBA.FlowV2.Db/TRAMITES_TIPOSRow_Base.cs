// <fileinfo name="TRAMITES_TIPOSRow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="TRAMITES_TIPOSRow"/> that 
	/// represents a record in the <c>TRAMITES_TIPOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMITES_TIPOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_TIPOSRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _descripcion;
		private string _presupuesto_toma_etapas;
		private string _estado;
		private string _mostrar_medidas;
		private string _mostrar_alcance;
		private string _mostrar_prof_recusados;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_TIPOSRow_Base"/> class.
		/// </summary>
		public TRAMITES_TIPOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMITES_TIPOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.PRESUPUESTO_TOMA_ETAPAS != original.PRESUPUESTO_TOMA_ETAPAS) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.MOSTRAR_MEDIDAS != original.MOSTRAR_MEDIDAS) return true;
			if (this.MOSTRAR_ALCANCE != original.MOSTRAR_ALCANCE) return true;
			if (this.MOSTRAR_PROF_RECUSADOS != original.MOSTRAR_PROF_RECUSADOS) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_TOMA_ETAPAS</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_TOMA_ETAPAS</c> column value.</value>
		public string PRESUPUESTO_TOMA_ETAPAS
		{
			get { return _presupuesto_toma_etapas; }
			set { _presupuesto_toma_etapas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOSTRAR_MEDIDAS</c> column value.
		/// </summary>
		/// <value>The <c>MOSTRAR_MEDIDAS</c> column value.</value>
		public string MOSTRAR_MEDIDAS
		{
			get { return _mostrar_medidas; }
			set { _mostrar_medidas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOSTRAR_ALCANCE</c> column value.
		/// </summary>
		/// <value>The <c>MOSTRAR_ALCANCE</c> column value.</value>
		public string MOSTRAR_ALCANCE
		{
			get { return _mostrar_alcance; }
			set { _mostrar_alcance = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOSTRAR_PROF_RECUSADOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOSTRAR_PROF_RECUSADOS</c> column value.</value>
		public string MOSTRAR_PROF_RECUSADOS
		{
			get { return _mostrar_prof_recusados; }
			set { _mostrar_prof_recusados = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@PRESUPUESTO_TOMA_ETAPAS=");
			dynStr.Append(PRESUPUESTO_TOMA_ETAPAS);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@MOSTRAR_MEDIDAS=");
			dynStr.Append(MOSTRAR_MEDIDAS);
			dynStr.Append("@CBA@MOSTRAR_ALCANCE=");
			dynStr.Append(MOSTRAR_ALCANCE);
			dynStr.Append("@CBA@MOSTRAR_PROF_RECUSADOS=");
			dynStr.Append(MOSTRAR_PROF_RECUSADOS);
			return dynStr.ToString();
		}
	} // End of TRAMITES_TIPOSRow_Base class
} // End of namespace

// <fileinfo name="TIPOS_ENTRADA_LEGAJORow_Base.cs">
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
	/// The base class for <see cref="TIPOS_ENTRADA_LEGAJORow"/> that 
	/// represents a record in the <c>TIPOS_ENTRADA_LEGAJO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPOS_ENTRADA_LEGAJORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_ENTRADA_LEGAJORow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _descripcion;
		private string _requeire_fecha_inicio;
		private string _requiere_fecha_fin;
		private string _editable;
		private string _estado;
		private decimal _orden;
		private decimal _entidad_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_ENTRADA_LEGAJORow_Base"/> class.
		/// </summary>
		public TIPOS_ENTRADA_LEGAJORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPOS_ENTRADA_LEGAJORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.REQUEIRE_FECHA_INICIO != original.REQUEIRE_FECHA_INICIO) return true;
			if (this.REQUIERE_FECHA_FIN != original.REQUIERE_FECHA_FIN) return true;
			if (this.EDITABLE != original.EDITABLE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.ORDEN != original.ORDEN) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			
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
		/// Gets or sets the <c>REQUEIRE_FECHA_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>REQUEIRE_FECHA_INICIO</c> column value.</value>
		public string REQUEIRE_FECHA_INICIO
		{
			get { return _requeire_fecha_inicio; }
			set { _requeire_fecha_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REQUIERE_FECHA_FIN</c> column value.
		/// </summary>
		/// <value>The <c>REQUIERE_FECHA_FIN</c> column value.</value>
		public string REQUIERE_FECHA_FIN
		{
			get { return _requiere_fecha_fin; }
			set { _requiere_fecha_fin = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDITABLE</c> column value.
		/// </summary>
		/// <value>The <c>EDITABLE</c> column value.</value>
		public string EDITABLE
		{
			get { return _editable; }
			set { _editable = value; }
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
		/// Gets or sets the <c>ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get { return _orden; }
			set { _orden = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
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
			dynStr.Append("@CBA@REQUEIRE_FECHA_INICIO=");
			dynStr.Append(REQUEIRE_FECHA_INICIO);
			dynStr.Append("@CBA@REQUIERE_FECHA_FIN=");
			dynStr.Append(REQUIERE_FECHA_FIN);
			dynStr.Append("@CBA@EDITABLE=");
			dynStr.Append(EDITABLE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			return dynStr.ToString();
		}
	} // End of TIPOS_ENTRADA_LEGAJORow_Base class
} // End of namespace

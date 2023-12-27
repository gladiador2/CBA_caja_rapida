// <fileinfo name="CTACTE_CHQ_TRAN_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHQ_TRAN_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CTACTE_CHQ_TRAN_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CHQ_TRAN_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHQ_TRAN_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _estado_origen_id;
		private string _estado_origen_nombre;
		private string _estado_origen_alias;
		private decimal _estado_destino_id;
		private string _estado_destino_nombre;
		private string _estado_destino_alias;
		private decimal _rol_id;
		private string _rol_descripcion;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHQ_TRAN_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CTACTE_CHQ_TRAN_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CHQ_TRAN_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ESTADO_ORIGEN_ID != original.ESTADO_ORIGEN_ID) return true;
			if (this.ESTADO_ORIGEN_NOMBRE != original.ESTADO_ORIGEN_NOMBRE) return true;
			if (this.ESTADO_ORIGEN_ALIAS != original.ESTADO_ORIGEN_ALIAS) return true;
			if (this.ESTADO_DESTINO_ID != original.ESTADO_DESTINO_ID) return true;
			if (this.ESTADO_DESTINO_NOMBRE != original.ESTADO_DESTINO_NOMBRE) return true;
			if (this.ESTADO_DESTINO_ALIAS != original.ESTADO_DESTINO_ALIAS) return true;
			if (this.ROL_ID != original.ROL_ID) return true;
			if (this.ROL_DESCRIPCION != original.ROL_DESCRIPCION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>ESTADO_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_ORIGEN_ID</c> column value.</value>
		public decimal ESTADO_ORIGEN_ID
		{
			get { return _estado_origen_id; }
			set { _estado_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ORIGEN_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_ORIGEN_NOMBRE</c> column value.</value>
		public string ESTADO_ORIGEN_NOMBRE
		{
			get { return _estado_origen_nombre; }
			set { _estado_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ORIGEN_ALIAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ORIGEN_ALIAS</c> column value.</value>
		public string ESTADO_ORIGEN_ALIAS
		{
			get { return _estado_origen_alias; }
			set { _estado_origen_alias = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_DESTINO_ID</c> column value.</value>
		public decimal ESTADO_DESTINO_ID
		{
			get { return _estado_destino_id; }
			set { _estado_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DESTINO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_DESTINO_NOMBRE</c> column value.</value>
		public string ESTADO_DESTINO_NOMBRE
		{
			get { return _estado_destino_nombre; }
			set { _estado_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DESTINO_ALIAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_DESTINO_ALIAS</c> column value.</value>
		public string ESTADO_DESTINO_ALIAS
		{
			get { return _estado_destino_alias; }
			set { _estado_destino_alias = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_ID</c> column value.
		/// </summary>
		/// <value>The <c>ROL_ID</c> column value.</value>
		public decimal ROL_ID
		{
			get { return _rol_id; }
			set { _rol_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_DESCRIPCION</c> column value.</value>
		public string ROL_DESCRIPCION
		{
			get { return _rol_descripcion; }
			set { _rol_descripcion = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@ESTADO_ORIGEN_ID=");
			dynStr.Append(ESTADO_ORIGEN_ID);
			dynStr.Append("@CBA@ESTADO_ORIGEN_NOMBRE=");
			dynStr.Append(ESTADO_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@ESTADO_ORIGEN_ALIAS=");
			dynStr.Append(ESTADO_ORIGEN_ALIAS);
			dynStr.Append("@CBA@ESTADO_DESTINO_ID=");
			dynStr.Append(ESTADO_DESTINO_ID);
			dynStr.Append("@CBA@ESTADO_DESTINO_NOMBRE=");
			dynStr.Append(ESTADO_DESTINO_NOMBRE);
			dynStr.Append("@CBA@ESTADO_DESTINO_ALIAS=");
			dynStr.Append(ESTADO_DESTINO_ALIAS);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(ROL_ID);
			dynStr.Append("@CBA@ROL_DESCRIPCION=");
			dynStr.Append(ROL_DESCRIPCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_CHQ_TRAN_INFO_COMPLETARow_Base class
} // End of namespace

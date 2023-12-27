// <fileinfo name="CTB_ENTIDADES_CUENTASRow_Base.cs">
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
	/// The base class for <see cref="CTB_ENTIDADES_CUENTASRow"/> that 
	/// represents a record in the <c>CTB_ENTIDADES_CUENTAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ENTIDADES_CUENTASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ENTIDADES_CUENTASRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _log_campos_id;
		private decimal _ctb_cuenta_id;
		private System.DateTime _fecha_insercion;
		private decimal _usuario_id_insercion;
		private decimal _registro_id;
		private string _tipo;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ENTIDADES_CUENTASRow_Base"/> class.
		/// </summary>
		public CTB_ENTIDADES_CUENTASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ENTIDADES_CUENTASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.LOG_CAMPOS_ID != original.LOG_CAMPOS_ID) return true;
			if (this.CTB_CUENTA_ID != original.CTB_CUENTA_ID) return true;
			if (this.FECHA_INSERCION != original.FECHA_INSERCION) return true;
			if (this.USUARIO_ID_INSERCION != original.USUARIO_ID_INSERCION) return true;
			if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			if (this.TIPO != original.TIPO) return true;
			
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOG_CAMPOS_ID</c> column value.
		/// </summary>
		/// <value>The <c>LOG_CAMPOS_ID</c> column value.</value>
		public decimal LOG_CAMPOS_ID
		{
			get { return _log_campos_id; }
			set { _log_campos_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_ID</c> column value.</value>
		public decimal CTB_CUENTA_ID
		{
			get { return _ctb_cuenta_id; }
			set { _ctb_cuenta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INSERCION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INSERCION</c> column value.</value>
		public System.DateTime FECHA_INSERCION
		{
			get { return _fecha_insercion; }
			set { _fecha_insercion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID_INSERCION</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID_INSERCION</c> column value.</value>
		public decimal USUARIO_ID_INSERCION
		{
			get { return _usuario_id_insercion; }
			set { _usuario_id_insercion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REGISTRO_ID</c> column value.</value>
		public decimal REGISTRO_ID
		{
			get { return _registro_id; }
			set { _registro_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public string TIPO
		{
			get { return _tipo; }
			set { _tipo = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@LOG_CAMPOS_ID=");
			dynStr.Append(LOG_CAMPOS_ID);
			dynStr.Append("@CBA@CTB_CUENTA_ID=");
			dynStr.Append(CTB_CUENTA_ID);
			dynStr.Append("@CBA@FECHA_INSERCION=");
			dynStr.Append(FECHA_INSERCION);
			dynStr.Append("@CBA@USUARIO_ID_INSERCION=");
			dynStr.Append(USUARIO_ID_INSERCION);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(REGISTRO_ID);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			return dynStr.ToString();
		}
	} // End of CTB_ENTIDADES_CUENTASRow_Base class
} // End of namespace

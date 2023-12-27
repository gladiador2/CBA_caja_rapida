// <fileinfo name="PERSONAS_LINEA_CREDITORow_Base.cs">
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
	/// The base class for <see cref="PERSONAS_LINEA_CREDITORow"/> that 
	/// represents a record in the <c>PERSONAS_LINEA_CREDITO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONAS_LINEA_CREDITORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_LINEA_CREDITORow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private decimal _monto_linea_credito;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private System.DateTime _fecha_asignacion;
		private decimal _usuario_asignacion;
		private string _temporal;
		private string _aprobado;
		private string _utilizado;
		private decimal _usuario_aprobacion;
		private bool _usuario_aprobacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_LINEA_CREDITORow_Base"/> class.
		/// </summary>
		public PERSONAS_LINEA_CREDITORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONAS_LINEA_CREDITORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.MONTO_LINEA_CREDITO != original.MONTO_LINEA_CREDITO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.FECHA_ASIGNACION != original.FECHA_ASIGNACION) return true;
			if (this.USUARIO_ASIGNACION != original.USUARIO_ASIGNACION) return true;
			if (this.TEMPORAL != original.TEMPORAL) return true;
			if (this.APROBADO != original.APROBADO) return true;
			if (this.UTILIZADO != original.UTILIZADO) return true;
			if (this.IsUSUARIO_APROBACIONNull != original.IsUSUARIO_APROBACIONNull) return true;
			if (!this.IsUSUARIO_APROBACIONNull && !original.IsUSUARIO_APROBACIONNull)
				if (this.USUARIO_APROBACION != original.USUARIO_APROBACION) return true;
			
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_LINEA_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_LINEA_CREDITO</c> column value.</value>
		public decimal MONTO_LINEA_CREDITO
		{
			get { return _monto_linea_credito; }
			set { _monto_linea_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ASIGNACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ASIGNACION</c> column value.</value>
		public System.DateTime FECHA_ASIGNACION
		{
			get { return _fecha_asignacion; }
			set { _fecha_asignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ASIGNACION</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ASIGNACION</c> column value.</value>
		public decimal USUARIO_ASIGNACION
		{
			get { return _usuario_asignacion; }
			set { _usuario_asignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEMPORAL</c> column value.
		/// </summary>
		/// <value>The <c>TEMPORAL</c> column value.</value>
		public string TEMPORAL
		{
			get { return _temporal; }
			set { _temporal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APROBADO</c> column value.</value>
		public string APROBADO
		{
			get { return _aprobado; }
			set { _aprobado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UTILIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UTILIZADO</c> column value.</value>
		public string UTILIZADO
		{
			get { return _utilizado; }
			set { _utilizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_APROBACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_APROBACION</c> column value.</value>
		public decimal USUARIO_APROBACION
		{
			get
			{
				if(IsUSUARIO_APROBACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_aprobacion;
			}
			set
			{
				_usuario_aprobacionNull = false;
				_usuario_aprobacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_APROBACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_APROBACIONNull
		{
			get { return _usuario_aprobacionNull; }
			set { _usuario_aprobacionNull = value; }
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
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@MONTO_LINEA_CREDITO=");
			dynStr.Append(MONTO_LINEA_CREDITO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@FECHA_ASIGNACION=");
			dynStr.Append(FECHA_ASIGNACION);
			dynStr.Append("@CBA@USUARIO_ASIGNACION=");
			dynStr.Append(USUARIO_ASIGNACION);
			dynStr.Append("@CBA@TEMPORAL=");
			dynStr.Append(TEMPORAL);
			dynStr.Append("@CBA@APROBADO=");
			dynStr.Append(APROBADO);
			dynStr.Append("@CBA@UTILIZADO=");
			dynStr.Append(UTILIZADO);
			dynStr.Append("@CBA@USUARIO_APROBACION=");
			dynStr.Append(IsUSUARIO_APROBACIONNull ? (object)"<NULL>" : USUARIO_APROBACION);
			return dynStr.ToString();
		}
	} // End of PERSONAS_LINEA_CREDITORow_Base class
} // End of namespace

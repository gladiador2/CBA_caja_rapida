// <fileinfo name="ASIGNACIONES_CARGOSRow_Base.cs">
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
	/// The base class for <see cref="ASIGNACIONES_CARGOSRow"/> that 
	/// represents a record in the <c>ASIGNACIONES_CARGOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ASIGNACIONES_CARGOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ASIGNACIONES_CARGOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private System.DateTime _fecha;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="ASIGNACIONES_CARGOSRow_Base"/> class.
		/// </summary>
		public ASIGNACIONES_CARGOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ASIGNACIONES_CARGOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of ASIGNACIONES_CARGOSRow_Base class
} // End of namespace

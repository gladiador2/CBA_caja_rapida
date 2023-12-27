// <fileinfo name="ACTIVOS_MOVIMIENTOSRow_Base.cs">
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
	/// The base class for <see cref="ACTIVOS_MOVIMIENTOSRow"/> that 
	/// represents a record in the <c>ACTIVOS_MOVIMIENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ACTIVOS_MOVIMIENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ACTIVOS_MOVIMIENTOSRow_Base
	{
		private decimal _id;
		private decimal _activo_id;
		private decimal _sucursal_origen_id;
		private decimal _sucursal_destino_id;
		private System.DateTime _fecha_movimiento;
		private decimal _usuario_movimiento_id;
		private string _observaciones;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ACTIVOS_MOVIMIENTOSRow_Base"/> class.
		/// </summary>
		public ACTIVOS_MOVIMIENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ACTIVOS_MOVIMIENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.SUCURSAL_ORIGEN_ID != original.SUCURSAL_ORIGEN_ID) return true;
			if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.FECHA_MOVIMIENTO != original.FECHA_MOVIMIENTO) return true;
			if (this.USUARIO_MOVIMIENTO_ID != original.USUARIO_MOVIMIENTO_ID) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
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
		/// Gets or sets the <c>ACTIVO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ACTIVO_ID</c> column value.</value>
		public decimal ACTIVO_ID
		{
			get { return _activo_id; }
			set { _activo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ID</c> column value.</value>
		public decimal SUCURSAL_ORIGEN_ID
		{
			get { return _sucursal_origen_id; }
			set { _sucursal_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ID</c> column value.</value>
		public decimal SUCURSAL_DESTINO_ID
		{
			get { return _sucursal_destino_id; }
			set { _sucursal_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MOVIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_MOVIMIENTO</c> column value.</value>
		public System.DateTime FECHA_MOVIMIENTO
		{
			get { return _fecha_movimiento; }
			set { _fecha_movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_MOVIMIENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_MOVIMIENTO_ID</c> column value.</value>
		public decimal USUARIO_MOVIMIENTO_ID
		{
			get { return _usuario_movimiento_id; }
			set { _usuario_movimiento_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES</c> column value.</value>
		public string OBSERVACIONES
		{
			get { return _observaciones; }
			set { _observaciones = value; }
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
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(ACTIVO_ID);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ID=");
			dynStr.Append(SUCURSAL_ORIGEN_ID);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@FECHA_MOVIMIENTO=");
			dynStr.Append(FECHA_MOVIMIENTO);
			dynStr.Append("@CBA@USUARIO_MOVIMIENTO_ID=");
			dynStr.Append(USUARIO_MOVIMIENTO_ID);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ACTIVOS_MOVIMIENTOSRow_Base class
} // End of namespace

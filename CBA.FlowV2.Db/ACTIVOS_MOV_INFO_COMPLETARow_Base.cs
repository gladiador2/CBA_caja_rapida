// <fileinfo name="ACTIVOS_MOV_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ACTIVOS_MOV_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ACTIVOS_MOV_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _activo_id;
		private string _codigo;
		private string _nombre;
		private decimal _sucursal_origen_id;
		private string _sucursal_origen_nombre;
		private string _sucursal_origen_abreviatura;
		private decimal _sucursal_origen_region_id;
		private bool _sucursal_origen_region_idNull = true;
		private string _sucursal_origen_region_nombre;
		private decimal _sucursal_destino_id;
		private string _sucursal_destino_nombre;
		private string _sucursal_destino_abreviatura;
		private decimal _sucursal_destino_region_id;
		private bool _sucursal_destino_region_idNull = true;
		private string _sucursal_destino_region_nombre;
		private System.DateTime _fecha_movimiento;
		private decimal _usuario_movimiento_id;
		private string _usuario;
		private string _usuario_nombre;
		private string _observaciones;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ACTIVOS_MOV_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ACTIVOS_MOV_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ACTIVOS_MOV_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.SUCURSAL_ORIGEN_ID != original.SUCURSAL_ORIGEN_ID) return true;
			if (this.SUCURSAL_ORIGEN_NOMBRE != original.SUCURSAL_ORIGEN_NOMBRE) return true;
			if (this.SUCURSAL_ORIGEN_ABREVIATURA != original.SUCURSAL_ORIGEN_ABREVIATURA) return true;
			if (this.IsSUCURSAL_ORIGEN_REGION_IDNull != original.IsSUCURSAL_ORIGEN_REGION_IDNull) return true;
			if (!this.IsSUCURSAL_ORIGEN_REGION_IDNull && !original.IsSUCURSAL_ORIGEN_REGION_IDNull)
				if (this.SUCURSAL_ORIGEN_REGION_ID != original.SUCURSAL_ORIGEN_REGION_ID) return true;
			if (this.SUCURSAL_ORIGEN_REGION_NOMBRE != original.SUCURSAL_ORIGEN_REGION_NOMBRE) return true;
			if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.SUCURSAL_DESTINO_NOMBRE != original.SUCURSAL_DESTINO_NOMBRE) return true;
			if (this.SUCURSAL_DESTINO_ABREVIATURA != original.SUCURSAL_DESTINO_ABREVIATURA) return true;
			if (this.IsSUCURSAL_DESTINO_REGION_IDNull != original.IsSUCURSAL_DESTINO_REGION_IDNull) return true;
			if (!this.IsSUCURSAL_DESTINO_REGION_IDNull && !original.IsSUCURSAL_DESTINO_REGION_IDNull)
				if (this.SUCURSAL_DESTINO_REGION_ID != original.SUCURSAL_DESTINO_REGION_ID) return true;
			if (this.SUCURSAL_DESTINO_REGION_NOMBRE != original.SUCURSAL_DESTINO_REGION_NOMBRE) return true;
			if (this.FECHA_MOVIMIENTO != original.FECHA_MOVIMIENTO) return true;
			if (this.USUARIO_MOVIMIENTO_ID != original.USUARIO_MOVIMIENTO_ID) return true;
			if (this.USUARIO != original.USUARIO) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
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
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
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
		/// Gets or sets the <c>SUCURSAL_ORIGEN_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_NOMBRE</c> column value.</value>
		public string SUCURSAL_ORIGEN_NOMBRE
		{
			get { return _sucursal_origen_nombre; }
			set { _sucursal_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ORIGEN_ABREVIATURA
		{
			get { return _sucursal_origen_abreviatura; }
			set { _sucursal_origen_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_REGION_ID</c> column value.</value>
		public decimal SUCURSAL_ORIGEN_REGION_ID
		{
			get
			{
				if(IsSUCURSAL_ORIGEN_REGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_origen_region_id;
			}
			set
			{
				_sucursal_origen_region_idNull = false;
				_sucursal_origen_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ORIGEN_REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_ORIGEN_REGION_IDNull
		{
			get { return _sucursal_origen_region_idNull; }
			set { _sucursal_origen_region_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_REGION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_REGION_NOMBRE</c> column value.</value>
		public string SUCURSAL_ORIGEN_REGION_NOMBRE
		{
			get { return _sucursal_origen_region_nombre; }
			set { _sucursal_origen_region_nombre = value; }
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
		/// Gets or sets the <c>SUCURSAL_DESTINO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_NOMBRE</c> column value.</value>
		public string SUCURSAL_DESTINO_NOMBRE
		{
			get { return _sucursal_destino_nombre; }
			set { _sucursal_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_DESTINO_ABREVIATURA
		{
			get { return _sucursal_destino_abreviatura; }
			set { _sucursal_destino_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_REGION_ID</c> column value.</value>
		public decimal SUCURSAL_DESTINO_REGION_ID
		{
			get
			{
				if(IsSUCURSAL_DESTINO_REGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_destino_region_id;
			}
			set
			{
				_sucursal_destino_region_idNull = false;
				_sucursal_destino_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_DESTINO_REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_DESTINO_REGION_IDNull
		{
			get { return _sucursal_destino_region_idNull; }
			set { _sucursal_destino_region_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_REGION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_REGION_NOMBRE</c> column value.</value>
		public string SUCURSAL_DESTINO_REGION_NOMBRE
		{
			get { return _sucursal_destino_region_nombre; }
			set { _sucursal_destino_region_nombre = value; }
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
		/// Gets or sets the <c>USUARIO</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO</c> column value.</value>
		public string USUARIO
		{
			get { return _usuario; }
			set { _usuario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_NOMBRE</c> column value.</value>
		public string USUARIO_NOMBRE
		{
			get { return _usuario_nombre; }
			set { _usuario_nombre = value; }
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
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ID=");
			dynStr.Append(SUCURSAL_ORIGEN_ID);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_NOMBRE=");
			dynStr.Append(SUCURSAL_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ORIGEN_ABREVIATURA);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_REGION_ID=");
			dynStr.Append(IsSUCURSAL_ORIGEN_REGION_IDNull ? (object)"<NULL>" : SUCURSAL_ORIGEN_REGION_ID);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_REGION_NOMBRE=");
			dynStr.Append(SUCURSAL_ORIGEN_REGION_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_NOMBRE=");
			dynStr.Append(SUCURSAL_DESTINO_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ABREVIATURA=");
			dynStr.Append(SUCURSAL_DESTINO_ABREVIATURA);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_REGION_ID=");
			dynStr.Append(IsSUCURSAL_DESTINO_REGION_IDNull ? (object)"<NULL>" : SUCURSAL_DESTINO_REGION_ID);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_REGION_NOMBRE=");
			dynStr.Append(SUCURSAL_DESTINO_REGION_NOMBRE);
			dynStr.Append("@CBA@FECHA_MOVIMIENTO=");
			dynStr.Append(FECHA_MOVIMIENTO);
			dynStr.Append("@CBA@USUARIO_MOVIMIENTO_ID=");
			dynStr.Append(USUARIO_MOVIMIENTO_ID);
			dynStr.Append("@CBA@USUARIO=");
			dynStr.Append(USUARIO);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ACTIVOS_MOV_INFO_COMPLETARow_Base class
} // End of namespace

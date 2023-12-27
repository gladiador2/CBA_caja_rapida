// <fileinfo name="RUBROS_IVARow_Base.cs">
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
	/// The base class for <see cref="RUBROS_IVARow"/> that 
	/// represents a record in the <c>RUBROS_IVA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="RUBROS_IVARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RUBROS_IVARow_Base
	{
		private decimal _id;
		private string _codigo_rubro;
		private string _descripcion_rubro;
		private System.DateTime _fecha_creacion;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private decimal _prioridad;
		private bool _prioridadNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="RUBROS_IVARow_Base"/> class.
		/// </summary>
		public RUBROS_IVARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(RUBROS_IVARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CODIGO_RUBRO != original.CODIGO_RUBRO) return true;
			if (this.DESCRIPCION_RUBRO != original.DESCRIPCION_RUBRO) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsPRIORIDADNull != original.IsPRIORIDADNull) return true;
			if (!this.IsPRIORIDADNull && !original.IsPRIORIDADNull)
				if (this.PRIORIDAD != original.PRIORIDAD) return true;
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
		/// Gets or sets the <c>CODIGO_RUBRO</c> column value.
		/// </summary>
		/// <value>The <c>CODIGO_RUBRO</c> column value.</value>
		public string CODIGO_RUBRO
		{
			get { return _codigo_rubro; }
			set { _codigo_rubro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_RUBRO</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION_RUBRO</c> column value.</value>
		public string DESCRIPCION_RUBRO
		{
			get { return _descripcion_rubro; }
			set { _descripcion_rubro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get
			{
				if(IsUSUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id;
			}
			set
			{
				_usuario_idNull = false;
				_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_IDNull
		{
			get { return _usuario_idNull; }
			set { _usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRIORIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRIORIDAD</c> column value.</value>
		public decimal PRIORIDAD
		{
			get
			{
				if(IsPRIORIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _prioridad;
			}
			set
			{
				_prioridadNull = false;
				_prioridad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRIORIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRIORIDADNull
		{
			get { return _prioridadNull; }
			set { _prioridadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
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
			dynStr.Append("@CBA@CODIGO_RUBRO=");
			dynStr.Append(CODIGO_RUBRO);
			dynStr.Append("@CBA@DESCRIPCION_RUBRO=");
			dynStr.Append(DESCRIPCION_RUBRO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@PRIORIDAD=");
			dynStr.Append(IsPRIORIDADNull ? (object)"<NULL>" : PRIORIDAD);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of RUBROS_IVARow_Base class
} // End of namespace

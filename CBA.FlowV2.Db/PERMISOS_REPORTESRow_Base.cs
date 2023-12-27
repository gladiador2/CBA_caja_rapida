// <fileinfo name="PERMISOS_REPORTESRow_Base.cs">
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
	/// The base class for <see cref="PERMISOS_REPORTESRow"/> that 
	/// represents a record in the <c>PERMISOS_REPORTES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERMISOS_REPORTESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERMISOS_REPORTESRow_Base
	{
		private decimal _id;
		private decimal _tipo_reporte_id;
		private decimal _reporte_id;
		private bool _reporte_idNull = true;
		private decimal _rol_id;
		private bool _rol_idNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _entidad_id;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERMISOS_REPORTESRow_Base"/> class.
		/// </summary>
		public PERMISOS_REPORTESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERMISOS_REPORTESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_REPORTE_ID != original.TIPO_REPORTE_ID) return true;
			if (this.IsREPORTE_IDNull != original.IsREPORTE_IDNull) return true;
			if (!this.IsREPORTE_IDNull && !original.IsREPORTE_IDNull)
				if (this.REPORTE_ID != original.REPORTE_ID) return true;
			if (this.IsROL_IDNull != original.IsROL_IDNull) return true;
			if (!this.IsROL_IDNull && !original.IsROL_IDNull)
				if (this.ROL_ID != original.ROL_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			
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
		/// Gets or sets the <c>TIPO_REPORTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_REPORTE_ID</c> column value.</value>
		public decimal TIPO_REPORTE_ID
		{
			get { return _tipo_reporte_id; }
			set { _tipo_reporte_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPORTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REPORTE_ID</c> column value.</value>
		public decimal REPORTE_ID
		{
			get
			{
				if(IsREPORTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reporte_id;
			}
			set
			{
				_reporte_idNull = false;
				_reporte_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REPORTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREPORTE_IDNull
		{
			get { return _reporte_idNull; }
			set { _reporte_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_ID</c> column value.</value>
		public decimal ROL_ID
		{
			get
			{
				if(IsROL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rol_id;
			}
			set
			{
				_rol_idNull = false;
				_rol_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ROL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsROL_IDNull
		{
			get { return _rol_idNull; }
			set { _rol_idNull = value; }
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
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
			dynStr.Append("@CBA@TIPO_REPORTE_ID=");
			dynStr.Append(TIPO_REPORTE_ID);
			dynStr.Append("@CBA@REPORTE_ID=");
			dynStr.Append(IsREPORTE_IDNull ? (object)"<NULL>" : REPORTE_ID);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(IsROL_IDNull ? (object)"<NULL>" : ROL_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			return dynStr.ToString();
		}
	} // End of PERMISOS_REPORTESRow_Base class
} // End of namespace

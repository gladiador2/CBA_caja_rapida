// <fileinfo name="ARTICULOS_MARGEN_RENTABILIDADRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> that 
	/// represents a record in the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_MARGEN_RENTABILIDADRow_Base
	{
		private decimal _id;
		private decimal _articulos_id;
		private decimal _lista_precios_id;
		private decimal _sucursales_id;
		private bool _sucursales_idNull = true;
		private decimal _porcentaje;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private System.DateTime _fecha_creacion;
		private bool _fecha_creacionNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_MARGEN_RENTABILIDADRow_Base"/> class.
		/// </summary>
		public ARTICULOS_MARGEN_RENTABILIDADRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_MARGEN_RENTABILIDADRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULOS_ID != original.ARTICULOS_ID) return true;
			if (this.LISTA_PRECIOS_ID != original.LISTA_PRECIOS_ID) return true;
			if (this.IsSUCURSALES_IDNull != original.IsSUCURSALES_IDNull) return true;
			if (!this.IsSUCURSALES_IDNull && !original.IsSUCURSALES_IDNull)
				if (this.SUCURSALES_ID != original.SUCURSALES_ID) return true;
			if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.IsFECHA_CREACIONNull != original.IsFECHA_CREACIONNull) return true;
			if (!this.IsFECHA_CREACIONNull && !original.IsFECHA_CREACIONNull)
				if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
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
		/// Gets or sets the <c>ARTICULOS_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULOS_ID</c> column value.</value>
		public decimal ARTICULOS_ID
		{
			get { return _articulos_id; }
			set { _articulos_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIOS_ID</c> column value.
		/// </summary>
		/// <value>The <c>LISTA_PRECIOS_ID</c> column value.</value>
		public decimal LISTA_PRECIOS_ID
		{
			get { return _lista_precios_id; }
			set { _lista_precios_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSALES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSALES_ID</c> column value.</value>
		public decimal SUCURSALES_ID
		{
			get
			{
				if(IsSUCURSALES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursales_id;
			}
			set
			{
				_sucursales_idNull = false;
				_sucursales_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSALES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSALES_IDNull
		{
			get { return _sucursales_idNull; }
			set { _sucursales_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get { return _porcentaje; }
			set { _porcentaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
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
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get
			{
				if(IsFECHA_CREACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_creacion;
			}
			set
			{
				_fecha_creacionNull = false;
				_fecha_creacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CREACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CREACIONNull
		{
			get { return _fecha_creacionNull; }
			set { _fecha_creacionNull = value; }
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
			dynStr.Append("@CBA@ARTICULOS_ID=");
			dynStr.Append(ARTICULOS_ID);
			dynStr.Append("@CBA@LISTA_PRECIOS_ID=");
			dynStr.Append(LISTA_PRECIOS_ID);
			dynStr.Append("@CBA@SUCURSALES_ID=");
			dynStr.Append(IsSUCURSALES_IDNull ? (object)"<NULL>" : SUCURSALES_ID);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(PORCENTAJE);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(IsFECHA_CREACIONNull ? (object)"<NULL>" : FECHA_CREACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_MARGEN_RENTABILIDADRow_Base class
} // End of namespace

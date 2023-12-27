// <fileinfo name="ARTICULOS_COSTOS_CIERRESRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COSTOS_CIERRESRow"/> that 
	/// represents a record in the <c>ARTICULOS_COSTOS_CIERRES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_COSTOS_CIERRESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COSTOS_CIERRESRow_Base
	{
		private decimal _id;
		private decimal _region_id;
		private bool _region_idNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private System.DateTime _fecha_cierre;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_creacion_id;
		private decimal _art_costo_cierre_anterior_id;
		private bool _art_costo_cierre_anterior_idNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COSTOS_CIERRESRow_Base"/> class.
		/// </summary>
		public ARTICULOS_COSTOS_CIERRESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_COSTOS_CIERRESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsREGION_IDNull != original.IsREGION_IDNull) return true;
			if (!this.IsREGION_IDNull && !original.IsREGION_IDNull)
				if (this.REGION_ID != original.REGION_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.FECHA_CIERRE != original.FECHA_CIERRE) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.IsART_COSTO_CIERRE_ANTERIOR_IDNull != original.IsART_COSTO_CIERRE_ANTERIOR_IDNull) return true;
			if (!this.IsART_COSTO_CIERRE_ANTERIOR_IDNull && !original.IsART_COSTO_CIERRE_ANTERIOR_IDNull)
				if (this.ART_COSTO_CIERRE_ANTERIOR_ID != original.ART_COSTO_CIERRE_ANTERIOR_ID) return true;
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
		/// Gets or sets the <c>REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGION_ID</c> column value.</value>
		public decimal REGION_ID
		{
			get
			{
				if(IsREGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _region_id;
			}
			set
			{
				_region_idNull = false;
				_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGION_IDNull
		{
			get { return _region_idNull; }
			set { _region_idNull = value; }
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
		/// Gets or sets the <c>FECHA_CIERRE</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CIERRE</c> column value.</value>
		public System.DateTime FECHA_CIERRE
		{
			get { return _fecha_cierre; }
			set { _fecha_cierre = value; }
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
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.</value>
		public decimal ART_COSTO_CIERRE_ANTERIOR_ID
		{
			get
			{
				if(IsART_COSTO_CIERRE_ANTERIOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _art_costo_cierre_anterior_id;
			}
			set
			{
				_art_costo_cierre_anterior_idNull = false;
				_art_costo_cierre_anterior_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ART_COSTO_CIERRE_ANTERIOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsART_COSTO_CIERRE_ANTERIOR_IDNull
		{
			get { return _art_costo_cierre_anterior_idNull; }
			set { _art_costo_cierre_anterior_idNull = value; }
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
			dynStr.Append("@CBA@REGION_ID=");
			dynStr.Append(IsREGION_IDNull ? (object)"<NULL>" : REGION_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@FECHA_CIERRE=");
			dynStr.Append(FECHA_CIERRE);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@ART_COSTO_CIERRE_ANTERIOR_ID=");
			dynStr.Append(IsART_COSTO_CIERRE_ANTERIOR_IDNull ? (object)"<NULL>" : ART_COSTO_CIERRE_ANTERIOR_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_COSTOS_CIERRESRow_Base class
} // End of namespace

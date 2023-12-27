// <fileinfo name="REQUISITOS_FLUJO_DETALLERow_Base.cs">
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
	/// The base class for <see cref="REQUISITOS_FLUJO_DETALLERow"/> that 
	/// represents a record in the <c>REQUISITOS_FLUJO_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REQUISITOS_FLUJO_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REQUISITOS_FLUJO_DETALLERow_Base
	{
		private decimal _id;
		private decimal _requisito_flujo_id;
		private decimal _caso_id;
		private decimal _usuario_carga_id;
		private System.DateTime _fecha_carga;
		private string _estado;
		private System.DateTime _fecha_borrado;
		private bool _fecha_borradoNull = true;
		private decimal _usuario_borrado_id;
		private bool _usuario_borrado_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="REQUISITOS_FLUJO_DETALLERow_Base"/> class.
		/// </summary>
		public REQUISITOS_FLUJO_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REQUISITOS_FLUJO_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.REQUISITO_FLUJO_ID != original.REQUISITO_FLUJO_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.USUARIO_CARGA_ID != original.USUARIO_CARGA_ID) return true;
			if (this.FECHA_CARGA != original.FECHA_CARGA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsFECHA_BORRADONull != original.IsFECHA_BORRADONull) return true;
			if (!this.IsFECHA_BORRADONull && !original.IsFECHA_BORRADONull)
				if (this.FECHA_BORRADO != original.FECHA_BORRADO) return true;
			if (this.IsUSUARIO_BORRADO_IDNull != original.IsUSUARIO_BORRADO_IDNull) return true;
			if (!this.IsUSUARIO_BORRADO_IDNull && !original.IsUSUARIO_BORRADO_IDNull)
				if (this.USUARIO_BORRADO_ID != original.USUARIO_BORRADO_ID) return true;
			
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
		/// Gets or sets the <c>REQUISITO_FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REQUISITO_FLUJO_ID</c> column value.</value>
		public decimal REQUISITO_FLUJO_ID
		{
			get { return _requisito_flujo_id; }
			set { _requisito_flujo_id = value; }
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
		/// Gets or sets the <c>USUARIO_CARGA_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CARGA_ID</c> column value.</value>
		public decimal USUARIO_CARGA_ID
		{
			get { return _usuario_carga_id; }
			set { _usuario_carga_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CARGA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CARGA</c> column value.</value>
		public System.DateTime FECHA_CARGA
		{
			get { return _fecha_carga; }
			set { _fecha_carga = value; }
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
		/// Gets or sets the <c>FECHA_BORRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_BORRADO</c> column value.</value>
		public System.DateTime FECHA_BORRADO
		{
			get
			{
				if(IsFECHA_BORRADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_borrado;
			}
			set
			{
				_fecha_borradoNull = false;
				_fecha_borrado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_BORRADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_BORRADONull
		{
			get { return _fecha_borradoNull; }
			set { _fecha_borradoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_BORRADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_BORRADO_ID</c> column value.</value>
		public decimal USUARIO_BORRADO_ID
		{
			get
			{
				if(IsUSUARIO_BORRADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_borrado_id;
			}
			set
			{
				_usuario_borrado_idNull = false;
				_usuario_borrado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_BORRADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_BORRADO_IDNull
		{
			get { return _usuario_borrado_idNull; }
			set { _usuario_borrado_idNull = value; }
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
			dynStr.Append("@CBA@REQUISITO_FLUJO_ID=");
			dynStr.Append(REQUISITO_FLUJO_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@USUARIO_CARGA_ID=");
			dynStr.Append(USUARIO_CARGA_ID);
			dynStr.Append("@CBA@FECHA_CARGA=");
			dynStr.Append(FECHA_CARGA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_BORRADO=");
			dynStr.Append(IsFECHA_BORRADONull ? (object)"<NULL>" : FECHA_BORRADO);
			dynStr.Append("@CBA@USUARIO_BORRADO_ID=");
			dynStr.Append(IsUSUARIO_BORRADO_IDNull ? (object)"<NULL>" : USUARIO_BORRADO_ID);
			return dynStr.ToString();
		}
	} // End of REQUISITOS_FLUJO_DETALLERow_Base class
} // End of namespace

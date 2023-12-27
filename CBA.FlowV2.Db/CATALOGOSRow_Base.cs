// <fileinfo name="CATALOGOSRow_Base.cs">
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
	/// The base class for <see cref="CATALOGOSRow"/> that 
	/// represents a record in the <c>CATALOGOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CATALOGOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CATALOGOSRow_Base
	{
		private decimal _id;
		private string _nombre;
		private System.DateTime _fecha_desde;
		private bool _fecha_desdeNull = true;
		private System.DateTime _fecha_hasta;
		private bool _fecha_hastaNull = true;
		private string _estado;
		private decimal _tipo_catalogo_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="CATALOGOSRow_Base"/> class.
		/// </summary>
		public CATALOGOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CATALOGOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.IsFECHA_DESDENull != original.IsFECHA_DESDENull) return true;
			if (!this.IsFECHA_DESDENull && !original.IsFECHA_DESDENull)
				if (this.FECHA_DESDE != original.FECHA_DESDE) return true;
			if (this.IsFECHA_HASTANull != original.IsFECHA_HASTANull) return true;
			if (!this.IsFECHA_HASTANull && !original.IsFECHA_HASTANull)
				if (this.FECHA_HASTA != original.FECHA_HASTA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TIPO_CATALOGO_ID != original.TIPO_CATALOGO_ID) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESDE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESDE</c> column value.</value>
		public System.DateTime FECHA_DESDE
		{
			get
			{
				if(IsFECHA_DESDENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desde;
			}
			set
			{
				_fecha_desdeNull = false;
				_fecha_desde = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESDE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESDENull
		{
			get { return _fecha_desdeNull; }
			set { _fecha_desdeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_HASTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_HASTA</c> column value.</value>
		public System.DateTime FECHA_HASTA
		{
			get
			{
				if(IsFECHA_HASTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_hasta;
			}
			set
			{
				_fecha_hastaNull = false;
				_fecha_hasta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_HASTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_HASTANull
		{
			get { return _fecha_hastaNull; }
			set { _fecha_hastaNull = value; }
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
		/// Gets or sets the <c>TIPO_CATALOGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CATALOGO_ID</c> column value.</value>
		public decimal TIPO_CATALOGO_ID
		{
			get { return _tipo_catalogo_id; }
			set { _tipo_catalogo_id = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@FECHA_DESDE=");
			dynStr.Append(IsFECHA_DESDENull ? (object)"<NULL>" : FECHA_DESDE);
			dynStr.Append("@CBA@FECHA_HASTA=");
			dynStr.Append(IsFECHA_HASTANull ? (object)"<NULL>" : FECHA_HASTA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TIPO_CATALOGO_ID=");
			dynStr.Append(TIPO_CATALOGO_ID);
			return dynStr.ToString();
		}
	} // End of CATALOGOSRow_Base class
} // End of namespace

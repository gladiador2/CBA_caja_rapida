// <fileinfo name="OBJETIVO_VENDEDOR_ARTICULORow_Base.cs">
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
	/// The base class for <see cref="OBJETIVO_VENDEDOR_ARTICULORow"/> that 
	/// represents a record in the <c>OBJETIVO_VENDEDOR_ARTICULO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="OBJETIVO_VENDEDOR_ARTICULORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OBJETIVO_VENDEDOR_ARTICULORow_Base
	{
		private decimal _id;
		private decimal _articulo_temporada_id;
		private decimal _usuario_creador_id;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_modificador_id;
		private bool _usuario_modificador_idNull = true;
		private System.DateTime _fecha_modificacion;
		private bool _fecha_modificacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="OBJETIVO_VENDEDOR_ARTICULORow_Base"/> class.
		/// </summary>
		public OBJETIVO_VENDEDOR_ARTICULORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(OBJETIVO_VENDEDOR_ARTICULORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_TEMPORADA_ID != original.ARTICULO_TEMPORADA_ID) return true;
			if (this.USUARIO_CREADOR_ID != original.USUARIO_CREADOR_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsUSUARIO_MODIFICADOR_IDNull != original.IsUSUARIO_MODIFICADOR_IDNull) return true;
			if (!this.IsUSUARIO_MODIFICADOR_IDNull && !original.IsUSUARIO_MODIFICADOR_IDNull)
				if (this.USUARIO_MODIFICADOR_ID != original.USUARIO_MODIFICADOR_ID) return true;
			if (this.IsFECHA_MODIFICACIONNull != original.IsFECHA_MODIFICACIONNull) return true;
			if (!this.IsFECHA_MODIFICACIONNull && !original.IsFECHA_MODIFICACIONNull)
				if (this.FECHA_MODIFICACION != original.FECHA_MODIFICACION) return true;
			
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
		/// Gets or sets the <c>ARTICULO_TEMPORADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_TEMPORADA_ID</c> column value.</value>
		public decimal ARTICULO_TEMPORADA_ID
		{
			get { return _articulo_temporada_id; }
			set { _articulo_temporada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREADOR_ID</c> column value.</value>
		public decimal USUARIO_CREADOR_ID
		{
			get { return _usuario_creador_id; }
			set { _usuario_creador_id = value; }
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
		/// Gets or sets the <c>USUARIO_MODIFICADOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_MODIFICADOR_ID</c> column value.</value>
		public decimal USUARIO_MODIFICADOR_ID
		{
			get
			{
				if(IsUSUARIO_MODIFICADOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_modificador_id;
			}
			set
			{
				_usuario_modificador_idNull = false;
				_usuario_modificador_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_MODIFICADOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_MODIFICADOR_IDNull
		{
			get { return _usuario_modificador_idNull; }
			set { _usuario_modificador_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MODIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_MODIFICACION</c> column value.</value>
		public System.DateTime FECHA_MODIFICACION
		{
			get
			{
				if(IsFECHA_MODIFICACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_modificacion;
			}
			set
			{
				_fecha_modificacionNull = false;
				_fecha_modificacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_MODIFICACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_MODIFICACIONNull
		{
			get { return _fecha_modificacionNull; }
			set { _fecha_modificacionNull = value; }
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
			dynStr.Append("@CBA@ARTICULO_TEMPORADA_ID=");
			dynStr.Append(ARTICULO_TEMPORADA_ID);
			dynStr.Append("@CBA@USUARIO_CREADOR_ID=");
			dynStr.Append(USUARIO_CREADOR_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_MODIFICADOR_ID=");
			dynStr.Append(IsUSUARIO_MODIFICADOR_IDNull ? (object)"<NULL>" : USUARIO_MODIFICADOR_ID);
			dynStr.Append("@CBA@FECHA_MODIFICACION=");
			dynStr.Append(IsFECHA_MODIFICACIONNull ? (object)"<NULL>" : FECHA_MODIFICACION);
			return dynStr.ToString();
		}
	} // End of OBJETIVO_VENDEDOR_ARTICULORow_Base class
} // End of namespace

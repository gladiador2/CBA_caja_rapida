// <fileinfo name="CTB_ARCHIVOS_MARANGATURow_Base.cs">
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
	/// The base class for <see cref="CTB_ARCHIVOS_MARANGATURow"/> that 
	/// represents a record in the <c>CTB_ARCHIVOS_MARANGATU</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ARCHIVOS_MARANGATURow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ARCHIVOS_MARANGATURow_Base
	{
		private decimal _id;
		private string _periodo;
		private System.DateTime _fecha_creacion;
		private bool _fecha_creacionNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _tipo_registro;
		private decimal _version;
		private bool _versionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ARCHIVOS_MARANGATURow_Base"/> class.
		/// </summary>
		public CTB_ARCHIVOS_MARANGATURow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ARCHIVOS_MARANGATURow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERIODO != original.PERIODO) return true;
			if (this.IsFECHA_CREACIONNull != original.IsFECHA_CREACIONNull) return true;
			if (!this.IsFECHA_CREACIONNull && !original.IsFECHA_CREACIONNull)
				if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.TIPO_REGISTRO != original.TIPO_REGISTRO) return true;
			if (this.IsVERSIONNull != original.IsVERSIONNull) return true;
			if (!this.IsVERSIONNull && !original.IsVERSIONNull)
				if (this.VERSION != original.VERSION) return true;
			
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
		/// Gets or sets the <c>PERIODO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERIODO</c> column value.</value>
		public string PERIODO
		{
			get { return _periodo; }
			set { _periodo = value; }
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
		/// Gets or sets the <c>TIPO_REGISTRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_REGISTRO</c> column value.</value>
		public string TIPO_REGISTRO
		{
			get { return _tipo_registro; }
			set { _tipo_registro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VERSION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VERSION</c> column value.</value>
		public decimal VERSION
		{
			get
			{
				if(IsVERSIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _version;
			}
			set
			{
				_versionNull = false;
				_version = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VERSION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVERSIONNull
		{
			get { return _versionNull; }
			set { _versionNull = value; }
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
			dynStr.Append("@CBA@PERIODO=");
			dynStr.Append(PERIODO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(IsFECHA_CREACIONNull ? (object)"<NULL>" : FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@TIPO_REGISTRO=");
			dynStr.Append(TIPO_REGISTRO);
			dynStr.Append("@CBA@VERSION=");
			dynStr.Append(IsVERSIONNull ? (object)"<NULL>" : VERSION);
			return dynStr.ToString();
		}
	} // End of CTB_ARCHIVOS_MARANGATURow_Base class
} // End of namespace

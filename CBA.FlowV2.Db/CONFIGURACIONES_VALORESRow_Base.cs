// <fileinfo name="CONFIGURACIONES_VALORESRow_Base.cs">
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
	/// The base class for <see cref="CONFIGURACIONES_VALORESRow"/> that 
	/// represents a record in the <c>CONFIGURACIONES_VALORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONFIGURACIONES_VALORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONFIGURACIONES_VALORESRow_Base
	{
		private decimal _configuracion_id;
		private decimal _rol_id;
		private bool _rol_idNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _json;
		private decimal _id;
		private decimal _reporte_id;
		private bool _reporte_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONFIGURACIONES_VALORESRow_Base"/> class.
		/// </summary>
		public CONFIGURACIONES_VALORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONFIGURACIONES_VALORESRow_Base original)
		{
			if (this.CONFIGURACION_ID != original.CONFIGURACION_ID) return true;
			if (this.IsROL_IDNull != original.IsROL_IDNull) return true;
			if (!this.IsROL_IDNull && !original.IsROL_IDNull)
				if (this.ROL_ID != original.ROL_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.JSON != original.JSON) return true;
			if (this.ID != original.ID) return true;
			if (this.IsREPORTE_IDNull != original.IsREPORTE_IDNull) return true;
			if (!this.IsREPORTE_IDNull && !original.IsREPORTE_IDNull)
				if (this.REPORTE_ID != original.REPORTE_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>CONFIGURACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONFIGURACION_ID</c> column value.</value>
		public decimal CONFIGURACION_ID
		{
			get { return _configuracion_id; }
			set { _configuracion_id = value; }
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
		/// Gets or sets the <c>JSON</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>JSON</c> column value.</value>
		public string JSON
		{
			get { return _json; }
			set { _json = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@CONFIGURACION_ID=");
			dynStr.Append(CONFIGURACION_ID);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(IsROL_IDNull ? (object)"<NULL>" : ROL_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@JSON=");
			dynStr.Append(JSON);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@REPORTE_ID=");
			dynStr.Append(IsREPORTE_IDNull ? (object)"<NULL>" : REPORTE_ID);
			return dynStr.ToString();
		}
	} // End of CONFIGURACIONES_VALORESRow_Base class
} // End of namespace

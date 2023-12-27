// <fileinfo name="TEXTO_PREDEF_GRUPO_DET_INF_COMRow_Base.cs">
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
	/// The base class for <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> that 
	/// represents a record in the <c>TEXTO_PREDEF_GRUPO_DET_INF_COM</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TEXTO_PREDEF_GRUPO_DET_INF_COMRow_Base
	{
		private decimal _id;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _texto_predefinido;
		private decimal _texto_predefinido_grupo_id;
		private string _texto_pred_grupo_nombre;
		private string _texto_pred_grupo_estado;
		private decimal _texto_predef_g_hijo_id;
		private bool _texto_predef_g_hijo_idNull = true;
		private string _texto_predef_g_hijo_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow_Base"/> class.
		/// </summary>
		public TEXTO_PREDEF_GRUPO_DET_INF_COMRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TEXTO_PREDEF_GRUPO_DET_INF_COMRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO_PREDEFINIDO != original.TEXTO_PREDEFINIDO) return true;
			if (this.TEXTO_PREDEFINIDO_GRUPO_ID != original.TEXTO_PREDEFINIDO_GRUPO_ID) return true;
			if (this.TEXTO_PRED_GRUPO_NOMBRE != original.TEXTO_PRED_GRUPO_NOMBRE) return true;
			if (this.TEXTO_PRED_GRUPO_ESTADO != original.TEXTO_PRED_GRUPO_ESTADO) return true;
			if (this.IsTEXTO_PREDEF_G_HIJO_IDNull != original.IsTEXTO_PREDEF_G_HIJO_IDNull) return true;
			if (!this.IsTEXTO_PREDEF_G_HIJO_IDNull && !original.IsTEXTO_PREDEF_G_HIJO_IDNull)
				if (this.TEXTO_PREDEF_G_HIJO_ID != original.TEXTO_PREDEF_G_HIJO_ID) return true;
			if (this.TEXTO_PREDEF_G_HIJO_NOMBRE != original.TEXTO_PREDEF_G_HIJO_NOMBRE) return true;
			
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO</c> column value.</value>
		public string TEXTO_PREDEFINIDO
		{
			get { return _texto_predefinido; }
			set { _texto_predefinido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_GRUPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_GRUPO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_GRUPO_ID
		{
			get { return _texto_predefinido_grupo_id; }
			set { _texto_predefinido_grupo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PRED_GRUPO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PRED_GRUPO_NOMBRE</c> column value.</value>
		public string TEXTO_PRED_GRUPO_NOMBRE
		{
			get { return _texto_pred_grupo_nombre; }
			set { _texto_pred_grupo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PRED_GRUPO_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PRED_GRUPO_ESTADO</c> column value.</value>
		public string TEXTO_PRED_GRUPO_ESTADO
		{
			get { return _texto_pred_grupo_estado; }
			set { _texto_pred_grupo_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_G_HIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_G_HIJO_ID</c> column value.</value>
		public decimal TEXTO_PREDEF_G_HIJO_ID
		{
			get
			{
				if(IsTEXTO_PREDEF_G_HIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predef_g_hijo_id;
			}
			set
			{
				_texto_predef_g_hijo_idNull = false;
				_texto_predef_g_hijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEF_G_HIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEF_G_HIJO_IDNull
		{
			get { return _texto_predef_g_hijo_idNull; }
			set { _texto_predef_g_hijo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_G_HIJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_G_HIJO_NOMBRE</c> column value.</value>
		public string TEXTO_PREDEF_G_HIJO_NOMBRE
		{
			get { return _texto_predef_g_hijo_nombre; }
			set { _texto_predef_g_hijo_nombre = value; }
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
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO=");
			dynStr.Append(TEXTO_PREDEFINIDO);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_GRUPO_ID=");
			dynStr.Append(TEXTO_PREDEFINIDO_GRUPO_ID);
			dynStr.Append("@CBA@TEXTO_PRED_GRUPO_NOMBRE=");
			dynStr.Append(TEXTO_PRED_GRUPO_NOMBRE);
			dynStr.Append("@CBA@TEXTO_PRED_GRUPO_ESTADO=");
			dynStr.Append(TEXTO_PRED_GRUPO_ESTADO);
			dynStr.Append("@CBA@TEXTO_PREDEF_G_HIJO_ID=");
			dynStr.Append(IsTEXTO_PREDEF_G_HIJO_IDNull ? (object)"<NULL>" : TEXTO_PREDEF_G_HIJO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEF_G_HIJO_NOMBRE=");
			dynStr.Append(TEXTO_PREDEF_G_HIJO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of TEXTO_PREDEF_GRUPO_DET_INF_COMRow_Base class
} // End of namespace

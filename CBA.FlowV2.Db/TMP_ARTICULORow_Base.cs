// <fileinfo name="TMP_ARTICULORow_Base.cs">
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
	/// The base class for <see cref="TMP_ARTICULORow"/> that 
	/// represents a record in the <c>TMP_ARTICULO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TMP_ARTICULORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TMP_ARTICULORow_Base
	{
		private decimal _clave;
		private bool _claveNull = true;
		private decimal _id;
		private bool _idNull = true;
		private string _codigo;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private decimal _sub_grupo_id;
		private bool _sub_grupo_idNull = true;
		private string _descripcion_interna;
		private string _descripcion_impresion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TMP_ARTICULORow_Base"/> class.
		/// </summary>
		public TMP_ARTICULORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TMP_ARTICULORow_Base original)
		{
			if (this.IsCLAVENull != original.IsCLAVENull) return true;
			if (!this.IsCLAVENull && !original.IsCLAVENull)
				if (this.CLAVE != original.CLAVE) return true;
			if (this.IsIDNull != original.IsIDNull) return true;
			if (!this.IsIDNull && !original.IsIDNull)
				if (this.ID != original.ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.IsSUB_GRUPO_IDNull != original.IsSUB_GRUPO_IDNull) return true;
			if (!this.IsSUB_GRUPO_IDNull && !original.IsSUB_GRUPO_IDNull)
				if (this.SUB_GRUPO_ID != original.SUB_GRUPO_ID) return true;
			if (this.DESCRIPCION_INTERNA != original.DESCRIPCION_INTERNA) return true;
			if (this.DESCRIPCION_IMPRESION != original.DESCRIPCION_IMPRESION) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>CLAVE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLAVE</c> column value.</value>
		public decimal CLAVE
		{
			get
			{
				if(IsCLAVENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _clave;
			}
			set
			{
				_claveNull = false;
				_clave = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CLAVE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCLAVENull
		{
			get { return _claveNull; }
			set { _claveNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get
			{
				if(IsIDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _id;
			}
			set
			{
				_idNull = false;
				_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIDNull
		{
			get { return _idNull; }
			set { _idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_ID</c> column value.</value>
		public decimal FAMILIA_ID
		{
			get
			{
				if(IsFAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _familia_id;
			}
			set
			{
				_familia_idNull = false;
				_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFAMILIA_IDNull
		{
			get { return _familia_idNull; }
			set { _familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public decimal GRUPO_ID
		{
			get
			{
				if(IsGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_id;
			}
			set
			{
				_grupo_idNull = false;
				_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_IDNull
		{
			get { return _grupo_idNull; }
			set { _grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUB_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUB_GRUPO_ID</c> column value.</value>
		public decimal SUB_GRUPO_ID
		{
			get
			{
				if(IsSUB_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sub_grupo_id;
			}
			set
			{
				_sub_grupo_idNull = false;
				_sub_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUB_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUB_GRUPO_IDNull
		{
			get { return _sub_grupo_idNull; }
			set { _sub_grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_INTERNA</c> column value.</value>
		public string DESCRIPCION_INTERNA
		{
			get { return _descripcion_interna; }
			set { _descripcion_interna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_IMPRESION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_IMPRESION</c> column value.</value>
		public string DESCRIPCION_IMPRESION
		{
			get { return _descripcion_impresion; }
			set { _descripcion_impresion = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@CLAVE=");
			dynStr.Append(IsCLAVENull ? (object)"<NULL>" : CLAVE);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(IsIDNull ? (object)"<NULL>" : ID);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@SUB_GRUPO_ID=");
			dynStr.Append(IsSUB_GRUPO_IDNull ? (object)"<NULL>" : SUB_GRUPO_ID);
			dynStr.Append("@CBA@DESCRIPCION_INTERNA=");
			dynStr.Append(DESCRIPCION_INTERNA);
			dynStr.Append("@CBA@DESCRIPCION_IMPRESION=");
			dynStr.Append(DESCRIPCION_IMPRESION);
			return dynStr.ToString();
		}
	} // End of TMP_ARTICULORow_Base class
} // End of namespace

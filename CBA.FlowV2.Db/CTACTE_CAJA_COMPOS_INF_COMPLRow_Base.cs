// <fileinfo name="CTACTE_CAJA_COMPOS_INF_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJA_COMPOS_INF_COMPLRow"/> that 
	/// represents a record in the <c>CTACTE_CAJA_COMPOS_INF_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CAJA_COMPOS_INF_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJA_COMPOS_INF_COMPLRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _sucursal_abrev;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private decimal _funcionario_caja_suc;
		private bool _funcionario_caja_sucNull = true;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;
		private decimal _funcionario_fondo_fijo;
		private bool _funcionario_fondo_fijoNull = true;
		private string _fondo_fijo_nombre;
		private decimal _limite_superior_ff;
		private bool _limite_superior_ffNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJA_COMPOS_INF_COMPLRow_Base"/> class.
		/// </summary>
		public CTACTE_CAJA_COMPOS_INF_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CAJA_COMPOS_INF_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREV != original.SUCURSAL_ABREV) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsFUNCIONARIO_CAJA_SUCNull != original.IsFUNCIONARIO_CAJA_SUCNull) return true;
			if (!this.IsFUNCIONARIO_CAJA_SUCNull && !original.IsFUNCIONARIO_CAJA_SUCNull)
				if (this.FUNCIONARIO_CAJA_SUC != original.FUNCIONARIO_CAJA_SUC) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.IsFUNCIONARIO_FONDO_FIJONull != original.IsFUNCIONARIO_FONDO_FIJONull) return true;
			if (!this.IsFUNCIONARIO_FONDO_FIJONull && !original.IsFUNCIONARIO_FONDO_FIJONull)
				if (this.FUNCIONARIO_FONDO_FIJO != original.FUNCIONARIO_FONDO_FIJO) return true;
			if (this.FONDO_FIJO_NOMBRE != original.FONDO_FIJO_NOMBRE) return true;
			if (this.IsLIMITE_SUPERIOR_FFNull != original.IsLIMITE_SUPERIOR_FFNull) return true;
			if (!this.IsLIMITE_SUPERIOR_FFNull && !original.IsLIMITE_SUPERIOR_FFNull)
				if (this.LIMITE_SUPERIOR_FF != original.LIMITE_SUPERIOR_FF) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREV</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREV</c> column value.</value>
		public string SUCURSAL_ABREV
		{
			get { return _sucursal_abrev; }
			set { _sucursal_abrev = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_sucursal_id;
			}
			set
			{
				_ctacte_caja_sucursal_idNull = false;
				_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _ctacte_caja_sucursal_idNull; }
			set { _ctacte_caja_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CAJA_SUC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CAJA_SUC</c> column value.</value>
		public decimal FUNCIONARIO_CAJA_SUC
		{
			get
			{
				if(IsFUNCIONARIO_CAJA_SUCNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_caja_suc;
			}
			set
			{
				_funcionario_caja_sucNull = false;
				_funcionario_caja_suc = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_CAJA_SUC"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_CAJA_SUCNull
		{
			get { return _funcionario_caja_sucNull; }
			set { _funcionario_caja_sucNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_ID</c> column value.</value>
		public decimal CTACTE_FONDO_FIJO_ID
		{
			get
			{
				if(IsCTACTE_FONDO_FIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_fondo_fijo_id;
			}
			set
			{
				_ctacte_fondo_fijo_idNull = false;
				_ctacte_fondo_fijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_FONDO_FIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_FONDO_FIJO_IDNull
		{
			get { return _ctacte_fondo_fijo_idNull; }
			set { _ctacte_fondo_fijo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_FONDO_FIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_FONDO_FIJO</c> column value.</value>
		public decimal FUNCIONARIO_FONDO_FIJO
		{
			get
			{
				if(IsFUNCIONARIO_FONDO_FIJONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_fondo_fijo;
			}
			set
			{
				_funcionario_fondo_fijoNull = false;
				_funcionario_fondo_fijo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_FONDO_FIJO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_FONDO_FIJONull
		{
			get { return _funcionario_fondo_fijoNull; }
			set { _funcionario_fondo_fijoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FONDO_FIJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FONDO_FIJO_NOMBRE</c> column value.</value>
		public string FONDO_FIJO_NOMBRE
		{
			get { return _fondo_fijo_nombre; }
			set { _fondo_fijo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_SUPERIOR_FF</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIMITE_SUPERIOR_FF</c> column value.</value>
		public decimal LIMITE_SUPERIOR_FF
		{
			get
			{
				if(IsLIMITE_SUPERIOR_FFNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _limite_superior_ff;
			}
			set
			{
				_limite_superior_ffNull = false;
				_limite_superior_ff = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIMITE_SUPERIOR_FF"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIMITE_SUPERIOR_FFNull
		{
			get { return _limite_superior_ffNull; }
			set { _limite_superior_ffNull = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREV=");
			dynStr.Append(SUCURSAL_ABREV);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@FUNCIONARIO_CAJA_SUC=");
			dynStr.Append(IsFUNCIONARIO_CAJA_SUCNull ? (object)"<NULL>" : FUNCIONARIO_CAJA_SUC);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_FONDO_FIJO=");
			dynStr.Append(IsFUNCIONARIO_FONDO_FIJONull ? (object)"<NULL>" : FUNCIONARIO_FONDO_FIJO);
			dynStr.Append("@CBA@FONDO_FIJO_NOMBRE=");
			dynStr.Append(FONDO_FIJO_NOMBRE);
			dynStr.Append("@CBA@LIMITE_SUPERIOR_FF=");
			dynStr.Append(IsLIMITE_SUPERIOR_FFNull ? (object)"<NULL>" : LIMITE_SUPERIOR_FF);
			return dynStr.ToString();
		}
	} // End of CTACTE_CAJA_COMPOS_INF_COMPLRow_Base class
} // End of namespace

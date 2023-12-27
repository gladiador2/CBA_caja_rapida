// <fileinfo name="ENVASESRow_Base.cs">
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
	/// The base class for <see cref="ENVASESRow"/> that 
	/// represents a record in the <c>ENVASES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ENVASESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ENVASESRow_Base
	{
		private decimal _id;
		private string _codigo;
		private string _nombre;
		private string _unidad_id;
		private string _pesable;
		private decimal _peso;
		private bool _pesoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ENVASESRow_Base"/> class.
		/// </summary>
		public ENVASESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ENVASESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.UNIDAD_ID != original.UNIDAD_ID) return true;
			if (this.PESABLE != original.PESABLE) return true;
			if (this.IsPESONull != original.IsPESONull) return true;
			if (!this.IsPESONull && !original.IsPESONull)
				if (this.PESO != original.PESO) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_ID</c> column value.</value>
		public string UNIDAD_ID
		{
			get { return _unidad_id; }
			set { _unidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESABLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESABLE</c> column value.</value>
		public string PESABLE
		{
			get { return _pesable; }
			set { _pesable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO</c> column value.</value>
		public decimal PESO
		{
			get
			{
				if(IsPESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso;
			}
			set
			{
				_pesoNull = false;
				_peso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESONull
		{
			get { return _pesoNull; }
			set { _pesoNull = value; }
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
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@UNIDAD_ID=");
			dynStr.Append(UNIDAD_ID);
			dynStr.Append("@CBA@PESABLE=");
			dynStr.Append(PESABLE);
			dynStr.Append("@CBA@PESO=");
			dynStr.Append(IsPESONull ? (object)"<NULL>" : PESO);
			return dynStr.ToString();
		}
	} // End of ENVASESRow_Base class
} // End of namespace

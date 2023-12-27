// <fileinfo name="TRANSACCIONES_CIERRESRow_Base.cs">
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
	/// The base class for <see cref="TRANSACCIONES_CIERRESRow"/> that 
	/// represents a record in the <c>TRANSACCIONES_CIERRES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSACCIONES_CIERRESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSACCIONES_CIERRESRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _estado;
		private System.DateTime _menor_fecha_transaccion;
		private bool _menor_fecha_transaccionNull = true;
		private System.DateTime _mayor_fecha_transaccion;
		private bool _mayor_fecha_transaccionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSACCIONES_CIERRESRow_Base"/> class.
		/// </summary>
		public TRANSACCIONES_CIERRESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSACCIONES_CIERRESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsMENOR_FECHA_TRANSACCIONNull != original.IsMENOR_FECHA_TRANSACCIONNull) return true;
			if (!this.IsMENOR_FECHA_TRANSACCIONNull && !original.IsMENOR_FECHA_TRANSACCIONNull)
				if (this.MENOR_FECHA_TRANSACCION != original.MENOR_FECHA_TRANSACCION) return true;
			if (this.IsMAYOR_FECHA_TRANSACCIONNull != original.IsMAYOR_FECHA_TRANSACCIONNull) return true;
			if (!this.IsMAYOR_FECHA_TRANSACCIONNull && !original.IsMAYOR_FECHA_TRANSACCIONNull)
				if (this.MAYOR_FECHA_TRANSACCION != original.MAYOR_FECHA_TRANSACCION) return true;
			
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MENOR_FECHA_TRANSACCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MENOR_FECHA_TRANSACCION</c> column value.</value>
		public System.DateTime MENOR_FECHA_TRANSACCION
		{
			get
			{
				if(IsMENOR_FECHA_TRANSACCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _menor_fecha_transaccion;
			}
			set
			{
				_menor_fecha_transaccionNull = false;
				_menor_fecha_transaccion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MENOR_FECHA_TRANSACCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMENOR_FECHA_TRANSACCIONNull
		{
			get { return _menor_fecha_transaccionNull; }
			set { _menor_fecha_transaccionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MAYOR_FECHA_TRANSACCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MAYOR_FECHA_TRANSACCION</c> column value.</value>
		public System.DateTime MAYOR_FECHA_TRANSACCION
		{
			get
			{
				if(IsMAYOR_FECHA_TRANSACCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _mayor_fecha_transaccion;
			}
			set
			{
				_mayor_fecha_transaccionNull = false;
				_mayor_fecha_transaccion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MAYOR_FECHA_TRANSACCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMAYOR_FECHA_TRANSACCIONNull
		{
			get { return _mayor_fecha_transaccionNull; }
			set { _mayor_fecha_transaccionNull = value; }
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
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@MENOR_FECHA_TRANSACCION=");
			dynStr.Append(IsMENOR_FECHA_TRANSACCIONNull ? (object)"<NULL>" : MENOR_FECHA_TRANSACCION);
			dynStr.Append("@CBA@MAYOR_FECHA_TRANSACCION=");
			dynStr.Append(IsMAYOR_FECHA_TRANSACCIONNull ? (object)"<NULL>" : MAYOR_FECHA_TRANSACCION);
			return dynStr.ToString();
		}
	} // End of TRANSACCIONES_CIERRESRow_Base class
} // End of namespace

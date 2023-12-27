// <fileinfo name="ZONAS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ZONAS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ZONAS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ZONAS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ZONAS_INFO_COMPLETARow_Base
	{
		private string _nombre;
		private string _abreviatura;
		private decimal _id;
		private string _estado;
		private decimal _sucursal_id;
		private decimal _ciudad_id;
		private bool _ciudad_idNull = true;
		private string _nombre_ciudad;
		private string _sucursal_abreviatura;
		private string _sucursal_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="ZONAS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ZONAS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ZONAS_INFO_COMPLETARow_Base original)
		{
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.ID != original.ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsCIUDAD_IDNull != original.IsCIUDAD_IDNull) return true;
			if (!this.IsCIUDAD_IDNull && !original.IsCIUDAD_IDNull)
				if (this.CIUDAD_ID != original.CIUDAD_ID) return true;
			if (this.NOMBRE_CIUDAD != original.NOMBRE_CIUDAD) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			
			return false;
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
		/// Gets or sets the <c>ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ABREVIATURA</c> column value.</value>
		public string ABREVIATURA
		{
			get { return _abreviatura; }
			set { _abreviatura = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
		/// Gets or sets the <c>CIUDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD_ID</c> column value.</value>
		public decimal CIUDAD_ID
		{
			get
			{
				if(IsCIUDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ciudad_id;
			}
			set
			{
				_ciudad_idNull = false;
				_ciudad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIUDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIUDAD_IDNull
		{
			get { return _ciudad_idNull; }
			set { _ciudad_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_CIUDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_CIUDAD</c> column value.</value>
		public string NOMBRE_CIUDAD
		{
			get { return _nombre_ciudad; }
			set { _nombre_ciudad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@CIUDAD_ID=");
			dynStr.Append(IsCIUDAD_IDNull ? (object)"<NULL>" : CIUDAD_ID);
			dynStr.Append("@CBA@NOMBRE_CIUDAD=");
			dynStr.Append(NOMBRE_CIUDAD);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			return dynStr.ToString();
		}
	} // End of ZONAS_INFO_COMPLETARow_Base class
} // End of namespace

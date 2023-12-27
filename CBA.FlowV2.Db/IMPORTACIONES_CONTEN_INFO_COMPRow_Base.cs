// <fileinfo name="IMPORTACIONES_CONTEN_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="IMPORTACIONES_CONTEN_INFO_COMPRow"/> that 
	/// represents a record in the <c>IMPORTACIONES_CONTEN_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPORTACIONES_CONTEN_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACIONES_CONTEN_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _tipo_contenedor_id;
		private string _tipo_contenedor_clasificacion;
		private decimal _importacion_id;
		private decimal _cantidad;
		private decimal _cantidad_cajas;
		private bool _cantidad_cajasNull = true;
		private string _nombre_interno;
		private decimal _saldo;
		private bool _saldoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONES_CONTEN_INFO_COMPRow_Base"/> class.
		/// </summary>
		public IMPORTACIONES_CONTEN_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPORTACIONES_CONTEN_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_CONTENEDOR_ID != original.TIPO_CONTENEDOR_ID) return true;
			if (this.TIPO_CONTENEDOR_CLASIFICACION != original.TIPO_CONTENEDOR_CLASIFICACION) return true;
			if (this.IMPORTACION_ID != original.IMPORTACION_ID) return true;
			if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsCANTIDAD_CAJASNull != original.IsCANTIDAD_CAJASNull) return true;
			if (!this.IsCANTIDAD_CAJASNull && !original.IsCANTIDAD_CAJASNull)
				if (this.CANTIDAD_CAJAS != original.CANTIDAD_CAJAS) return true;
			if (this.NOMBRE_INTERNO != original.NOMBRE_INTERNO) return true;
			if (this.IsSALDONull != original.IsSALDONull) return true;
			if (!this.IsSALDONull && !original.IsSALDONull)
				if (this.SALDO != original.SALDO) return true;
			
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
		/// Gets or sets the <c>TIPO_CONTENEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CONTENEDOR_ID</c> column value.</value>
		public decimal TIPO_CONTENEDOR_ID
		{
			get { return _tipo_contenedor_id; }
			set { _tipo_contenedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CONTENEDOR_CLASIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CONTENEDOR_CLASIFICACION</c> column value.</value>
		public string TIPO_CONTENEDOR_CLASIFICACION
		{
			get { return _tipo_contenedor_clasificacion; }
			set { _tipo_contenedor_clasificacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPORTACION_ID</c> column value.</value>
		public decimal IMPORTACION_ID
		{
			get { return _importacion_id; }
			set { _importacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get { return _cantidad; }
			set { _cantidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_CAJAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_CAJAS</c> column value.</value>
		public decimal CANTIDAD_CAJAS
		{
			get
			{
				if(IsCANTIDAD_CAJASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_cajas;
			}
			set
			{
				_cantidad_cajasNull = false;
				_cantidad_cajas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_CAJAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_CAJASNull
		{
			get { return _cantidad_cajasNull; }
			set { _cantidad_cajasNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_INTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_INTERNO</c> column value.</value>
		public string NOMBRE_INTERNO
		{
			get { return _nombre_interno; }
			set { _nombre_interno = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO</c> column value.</value>
		public decimal SALDO
		{
			get
			{
				if(IsSALDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo;
			}
			set
			{
				_saldoNull = false;
				_saldo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDONull
		{
			get { return _saldoNull; }
			set { _saldoNull = value; }
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
			dynStr.Append("@CBA@TIPO_CONTENEDOR_ID=");
			dynStr.Append(TIPO_CONTENEDOR_ID);
			dynStr.Append("@CBA@TIPO_CONTENEDOR_CLASIFICACION=");
			dynStr.Append(TIPO_CONTENEDOR_CLASIFICACION);
			dynStr.Append("@CBA@IMPORTACION_ID=");
			dynStr.Append(IMPORTACION_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			dynStr.Append("@CBA@CANTIDAD_CAJAS=");
			dynStr.Append(IsCANTIDAD_CAJASNull ? (object)"<NULL>" : CANTIDAD_CAJAS);
			dynStr.Append("@CBA@NOMBRE_INTERNO=");
			dynStr.Append(NOMBRE_INTERNO);
			dynStr.Append("@CBA@SALDO=");
			dynStr.Append(IsSALDONull ? (object)"<NULL>" : SALDO);
			return dynStr.ToString();
		}
	} // End of IMPORTACIONES_CONTEN_INFO_COMPRow_Base class
} // End of namespace

// <fileinfo name="EGRESO_PRODUCTOS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> that 
	/// represents a record in the <c>EGRESO_PRODUCTOS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EGRESO_PRODUCTOS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EGRESO_PRODUCTOS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _egreso_producto_id;
		private string _chapa_camion;
		private string _chapa_carreta;
		private string _chofer_documento;
		private string _chofer_nombre;
		private string _chofer_telefono;
		private string _destino;
		private string _destino_cliente;
		private string _unidad_medida_id;
		private string _usar_cantidad;
		private decimal _presentacion_id;
		private bool _presentacion_idNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _cantidad_presentacion;
		private bool _cantidad_presentacionNull = true;
		private decimal _cantidad_bascula;
		private bool _cantidad_basculaNull = true;
		private string _usar_cantidad_bascula;
		private string _unidad_medida_bascula;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nrocomprobante;
		private string _marca;
		private decimal _ciudad_id;
		private bool _ciudad_idNull = true;
		private decimal _departamento_id;
		private bool _departamento_idNull = true;
		private string _chofer_direccion;

		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESO_PRODUCTOS_DETALLESRow_Base"/> class.
		/// </summary>
		public EGRESO_PRODUCTOS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EGRESO_PRODUCTOS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.EGRESO_PRODUCTO_ID != original.EGRESO_PRODUCTO_ID) return true;
			if (this.CHAPA_CAMION != original.CHAPA_CAMION) return true;
			if (this.CHAPA_CARRETA != original.CHAPA_CARRETA) return true;
			if (this.CHOFER_DOCUMENTO != original.CHOFER_DOCUMENTO) return true;
			if (this.CHOFER_NOMBRE != original.CHOFER_NOMBRE) return true;
			if (this.CHOFER_TELEFONO != original.CHOFER_TELEFONO) return true;
			if (this.DESTINO != original.DESTINO) return true;
			if (this.DESTINO_CLIENTE != original.DESTINO_CLIENTE) return true;
			if (this.UNIDAD_MEDIDA_ID != original.UNIDAD_MEDIDA_ID) return true;
			if (this.USAR_CANTIDAD != original.USAR_CANTIDAD) return true;
			if (this.IsPRESENTACION_IDNull != original.IsPRESENTACION_IDNull) return true;
			if (!this.IsPRESENTACION_IDNull && !original.IsPRESENTACION_IDNull)
				if (this.PRESENTACION_ID != original.PRESENTACION_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsCANTIDAD_PRESENTACIONNull != original.IsCANTIDAD_PRESENTACIONNull) return true;
			if (!this.IsCANTIDAD_PRESENTACIONNull && !original.IsCANTIDAD_PRESENTACIONNull)
				if (this.CANTIDAD_PRESENTACION != original.CANTIDAD_PRESENTACION) return true;
			if (this.IsCANTIDAD_BASCULANull != original.IsCANTIDAD_BASCULANull) return true;
			if (!this.IsCANTIDAD_BASCULANull && !original.IsCANTIDAD_BASCULANull)
				if (this.CANTIDAD_BASCULA != original.CANTIDAD_BASCULA) return true;
			if (this.USAR_CANTIDAD_BASCULA != original.USAR_CANTIDAD_BASCULA) return true;
			if (this.UNIDAD_MEDIDA_BASCULA != original.UNIDAD_MEDIDA_BASCULA) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NROCOMPROBANTE != original.NROCOMPROBANTE) return true;
			if (this.MARCA != original.MARCA) return true;
			if (this.IsCIUDAD_IDNull != original.IsCIUDAD_IDNull) return true;
			if (!this.IsCIUDAD_IDNull && !original.IsCIUDAD_IDNull)
				if (this.CIUDAD_ID != original.CIUDAD_ID) return true;
			if (this.IsDEPARTAMENTO_IDNull != original.IsDEPARTAMENTO_IDNull) return true;
			if (!this.IsDEPARTAMENTO_IDNull && !original.IsDEPARTAMENTO_IDNull)
				if (this.DEPARTAMENTO_ID != original.DEPARTAMENTO_ID) return true;
			if (this.CHOFER_DIRECCION != original.CHOFER_DIRECCION) return true;
			
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
		/// Gets or sets the <c>EGRESO_PRODUCTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>EGRESO_PRODUCTO_ID</c> column value.</value>
		public decimal EGRESO_PRODUCTO_ID
		{
			get { return _egreso_producto_id; }
			set { _egreso_producto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHAPA_CAMION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHAPA_CAMION</c> column value.</value>
		public string CHAPA_CAMION
		{
			get { return _chapa_camion; }
			set { _chapa_camion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHAPA_CARRETA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHAPA_CARRETA</c> column value.</value>
		public string CHAPA_CARRETA
		{
			get { return _chapa_carreta; }
			set { _chapa_carreta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_DOCUMENTO</c> column value.</value>
		public string CHOFER_DOCUMENTO
		{
			get { return _chofer_documento; }
			set { _chofer_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_NOMBRE</c> column value.</value>
		public string CHOFER_NOMBRE
		{
			get { return _chofer_nombre; }
			set { _chofer_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_TELEFONO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_TELEFONO</c> column value.</value>
		public string CHOFER_TELEFONO
		{
			get { return _chofer_telefono; }
			set { _chofer_telefono = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESTINO</c> column value.</value>
		public string DESTINO
		{
			get { return _destino; }
			set { _destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESTINO_CLIENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESTINO_CLIENTE</c> column value.</value>
		public string DESTINO_CLIENTE
		{
			get { return _destino_cliente; }
			set { _destino_cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ID
		{
			get { return _unidad_medida_id; }
			set { _unidad_medida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USAR_CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USAR_CANTIDAD</c> column value.</value>
		public string USAR_CANTIDAD
		{
			get { return _usar_cantidad; }
			set { _usar_cantidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESENTACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRESENTACION_ID</c> column value.</value>
		public decimal PRESENTACION_ID
		{
			get
			{
				if(IsPRESENTACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _presentacion_id;
			}
			set
			{
				_presentacion_idNull = false;
				_presentacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRESENTACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRESENTACION_IDNull
		{
			get { return _presentacion_idNull; }
			set { _presentacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_PRESENTACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_PRESENTACION</c> column value.</value>
		public decimal CANTIDAD_PRESENTACION
		{
			get
			{
				if(IsCANTIDAD_PRESENTACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_presentacion;
			}
			set
			{
				_cantidad_presentacionNull = false;
				_cantidad_presentacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_PRESENTACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_PRESENTACIONNull
		{
			get { return _cantidad_presentacionNull; }
			set { _cantidad_presentacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_BASCULA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_BASCULA</c> column value.</value>
		public decimal CANTIDAD_BASCULA
		{
			get
			{
				if(IsCANTIDAD_BASCULANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_bascula;
			}
			set
			{
				_cantidad_basculaNull = false;
				_cantidad_bascula = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_BASCULA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_BASCULANull
		{
			get { return _cantidad_basculaNull; }
			set { _cantidad_basculaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USAR_CANTIDAD_BASCULA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USAR_CANTIDAD_BASCULA</c> column value.</value>
		public string USAR_CANTIDAD_BASCULA
		{
			get { return _usar_cantidad_bascula; }
			set { _usar_cantidad_bascula = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_BASCULA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_BASCULA</c> column value.</value>
		public string UNIDAD_MEDIDA_BASCULA
		{
			get { return _unidad_medida_bascula; }
			set { _unidad_medida_bascula = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NROCOMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NROCOMPROBANTE</c> column value.</value>
		public string NROCOMPROBANTE
		{
			get { return _nrocomprobante; }
			set { _nrocomprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MARCA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MARCA</c> column value.</value>
		public string MARCA
		{
			get { return _marca; }
			set { _marca = value; }
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
		/// Gets or sets the <c>DEPARTAMENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO_ID</c> column value.</value>
		public decimal DEPARTAMENTO_ID
		{
			get
			{
				if(IsDEPARTAMENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _departamento_id;
			}
			set
			{
				_departamento_idNull = false;
				_departamento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPARTAMENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPARTAMENTO_IDNull
		{
			get { return _departamento_idNull; }
			set { _departamento_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_DIRECCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_DIRECCION</c> column value.</value>
		public string CHOFER_DIRECCION
		{
			get { return _chofer_direccion; }
			set { _chofer_direccion = value; }
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
			dynStr.Append("@CBA@EGRESO_PRODUCTO_ID=");
			dynStr.Append(EGRESO_PRODUCTO_ID);
			dynStr.Append("@CBA@CHAPA_CAMION=");
			dynStr.Append(CHAPA_CAMION);
			dynStr.Append("@CBA@CHAPA_CARRETA=");
			dynStr.Append(CHAPA_CARRETA);
			dynStr.Append("@CBA@CHOFER_DOCUMENTO=");
			dynStr.Append(CHOFER_DOCUMENTO);
			dynStr.Append("@CBA@CHOFER_NOMBRE=");
			dynStr.Append(CHOFER_NOMBRE);
			dynStr.Append("@CBA@CHOFER_TELEFONO=");
			dynStr.Append(CHOFER_TELEFONO);
			dynStr.Append("@CBA@DESTINO=");
			dynStr.Append(DESTINO);
			dynStr.Append("@CBA@DESTINO_CLIENTE=");
			dynStr.Append(DESTINO_CLIENTE);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@USAR_CANTIDAD=");
			dynStr.Append(USAR_CANTIDAD);
			dynStr.Append("@CBA@PRESENTACION_ID=");
			dynStr.Append(IsPRESENTACION_IDNull ? (object)"<NULL>" : PRESENTACION_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@CANTIDAD_PRESENTACION=");
			dynStr.Append(IsCANTIDAD_PRESENTACIONNull ? (object)"<NULL>" : CANTIDAD_PRESENTACION);
			dynStr.Append("@CBA@CANTIDAD_BASCULA=");
			dynStr.Append(IsCANTIDAD_BASCULANull ? (object)"<NULL>" : CANTIDAD_BASCULA);
			dynStr.Append("@CBA@USAR_CANTIDAD_BASCULA=");
			dynStr.Append(USAR_CANTIDAD_BASCULA);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_BASCULA=");
			dynStr.Append(UNIDAD_MEDIDA_BASCULA);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NROCOMPROBANTE=");
			dynStr.Append(NROCOMPROBANTE);
			dynStr.Append("@CBA@MARCA=");
			dynStr.Append(MARCA);
			dynStr.Append("@CBA@CIUDAD_ID=");
			dynStr.Append(IsCIUDAD_IDNull ? (object)"<NULL>" : CIUDAD_ID);
			dynStr.Append("@CBA@DEPARTAMENTO_ID=");
			dynStr.Append(IsDEPARTAMENTO_IDNull ? (object)"<NULL>" : DEPARTAMENTO_ID);
			dynStr.Append("@CBA@CHOFER_DIRECCION=");
			dynStr.Append(CHOFER_DIRECCION);
			return dynStr.ToString();
		}
	} // End of EGRESO_PRODUCTOS_DETALLESRow_Base class
} // End of namespace

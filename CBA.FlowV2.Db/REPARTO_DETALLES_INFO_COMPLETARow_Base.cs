// <fileinfo name="REPARTO_DETALLES_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>REPARTO_DETALLES_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPARTO_DETALLES_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _reparto_id;
		private string _caso_nro_comprobante;
		private decimal _caso_id;
		private string _caso_estado;
		private decimal _caso_flujo_id;
		private string _caso_flujo_desc_impr;
		private string _caso_flujo_descrip;
		private decimal _caso_sucursal_id;
		private string _caso_sucursal_nombre;
		private string _caso_sucursal_abreviatura;
		private System.DateTime _fecha_caso;
		private string _persona_nombre_completo;
		private string _persona_departamento1_nombre;
		private string _persona_ciudad1_nombre;
		private string _persona_barrio1_nombre;
		private string _persona_calle1;
		private decimal _orden;
		private bool _ordenNull = true;
		private string _observacion;
		private string _entrega_exitosa;
		private decimal _bultos;
		private bool _bultosNull = true;
		private decimal _transf_sucursal_destino_id;
		private bool _transf_sucursal_destino_idNull = true;
		private string _transf_sucursal_destino_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPARTO_DETALLES_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public REPARTO_DETALLES_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REPARTO_DETALLES_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.REPARTO_ID != original.REPARTO_ID) return true;
			if (this.CASO_NRO_COMPROBANTE != original.CASO_NRO_COMPROBANTE) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO != original.CASO_ESTADO) return true;
			if (this.CASO_FLUJO_ID != original.CASO_FLUJO_ID) return true;
			if (this.CASO_FLUJO_DESC_IMPR != original.CASO_FLUJO_DESC_IMPR) return true;
			if (this.CASO_FLUJO_DESCRIP != original.CASO_FLUJO_DESCRIP) return true;
			if (this.CASO_SUCURSAL_ID != original.CASO_SUCURSAL_ID) return true;
			if (this.CASO_SUCURSAL_NOMBRE != original.CASO_SUCURSAL_NOMBRE) return true;
			if (this.CASO_SUCURSAL_ABREVIATURA != original.CASO_SUCURSAL_ABREVIATURA) return true;
			if (this.FECHA_CASO != original.FECHA_CASO) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.PERSONA_DEPARTAMENTO1_NOMBRE != original.PERSONA_DEPARTAMENTO1_NOMBRE) return true;
			if (this.PERSONA_CIUDAD1_NOMBRE != original.PERSONA_CIUDAD1_NOMBRE) return true;
			if (this.PERSONA_BARRIO1_NOMBRE != original.PERSONA_BARRIO1_NOMBRE) return true;
			if (this.PERSONA_CALLE1 != original.PERSONA_CALLE1) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ENTREGA_EXITOSA != original.ENTREGA_EXITOSA) return true;
			if (this.IsBULTOSNull != original.IsBULTOSNull) return true;
			if (!this.IsBULTOSNull && !original.IsBULTOSNull)
				if (this.BULTOS != original.BULTOS) return true;
			if (this.IsTRANSF_SUCURSAL_DESTINO_IDNull != original.IsTRANSF_SUCURSAL_DESTINO_IDNull) return true;
			if (!this.IsTRANSF_SUCURSAL_DESTINO_IDNull && !original.IsTRANSF_SUCURSAL_DESTINO_IDNull)
				if (this.TRANSF_SUCURSAL_DESTINO_ID != original.TRANSF_SUCURSAL_DESTINO_ID) return true;
			if (this.TRANSF_SUCURSAL_DESTINO_NOMBRE != original.TRANSF_SUCURSAL_DESTINO_NOMBRE) return true;
			
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
		/// Gets or sets the <c>REPARTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REPARTO_ID</c> column value.</value>
		public decimal REPARTO_ID
		{
			get { return _reparto_id; }
			set { _reparto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_NRO_COMPROBANTE</c> column value.</value>
		public string CASO_NRO_COMPROBANTE
		{
			get { return _caso_nro_comprobante; }
			set { _caso_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO</c> column value.</value>
		public string CASO_ESTADO
		{
			get { return _caso_estado; }
			set { _caso_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_FLUJO_ID</c> column value.</value>
		public decimal CASO_FLUJO_ID
		{
			get { return _caso_flujo_id; }
			set { _caso_flujo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FLUJO_DESC_IMPR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_FLUJO_DESC_IMPR</c> column value.</value>
		public string CASO_FLUJO_DESC_IMPR
		{
			get { return _caso_flujo_desc_impr; }
			set { _caso_flujo_desc_impr = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FLUJO_DESCRIP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_FLUJO_DESCRIP</c> column value.</value>
		public string CASO_FLUJO_DESCRIP
		{
			get { return _caso_flujo_descrip; }
			set { _caso_flujo_descrip = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_SUCURSAL_ID</c> column value.</value>
		public decimal CASO_SUCURSAL_ID
		{
			get { return _caso_sucursal_id; }
			set { _caso_sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CASO_SUCURSAL_NOMBRE</c> column value.</value>
		public string CASO_SUCURSAL_NOMBRE
		{
			get { return _caso_sucursal_nombre; }
			set { _caso_sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>CASO_SUCURSAL_ABREVIATURA</c> column value.</value>
		public string CASO_SUCURSAL_ABREVIATURA
		{
			get { return _caso_sucursal_abreviatura; }
			set { _caso_sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CASO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CASO</c> column value.</value>
		public System.DateTime FECHA_CASO
		{
			get { return _fecha_caso; }
			set { _fecha_caso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE_COMPLETO</c> column value.</value>
		public string PERSONA_NOMBRE_COMPLETO
		{
			get { return _persona_nombre_completo; }
			set { _persona_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_DEPARTAMENTO1_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_DEPARTAMENTO1_NOMBRE</c> column value.</value>
		public string PERSONA_DEPARTAMENTO1_NOMBRE
		{
			get { return _persona_departamento1_nombre; }
			set { _persona_departamento1_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CIUDAD1_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CIUDAD1_NOMBRE</c> column value.</value>
		public string PERSONA_CIUDAD1_NOMBRE
		{
			get { return _persona_ciudad1_nombre; }
			set { _persona_ciudad1_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_BARRIO1_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_BARRIO1_NOMBRE</c> column value.</value>
		public string PERSONA_BARRIO1_NOMBRE
		{
			get { return _persona_barrio1_nombre; }
			set { _persona_barrio1_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CALLE1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CALLE1</c> column value.</value>
		public string PERSONA_CALLE1
		{
			get { return _persona_calle1; }
			set { _persona_calle1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get
			{
				if(IsORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden;
			}
			set
			{
				_ordenNull = false;
				_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENNull
		{
			get { return _ordenNull; }
			set { _ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTREGA_EXITOSA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTREGA_EXITOSA</c> column value.</value>
		public string ENTREGA_EXITOSA
		{
			get { return _entrega_exitosa; }
			set { _entrega_exitosa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BULTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BULTOS</c> column value.</value>
		public decimal BULTOS
		{
			get
			{
				if(IsBULTOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _bultos;
			}
			set
			{
				_bultosNull = false;
				_bultos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BULTOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBULTOSNull
		{
			get { return _bultosNull; }
			set { _bultosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSF_SUCURSAL_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSF_SUCURSAL_DESTINO_ID</c> column value.</value>
		public decimal TRANSF_SUCURSAL_DESTINO_ID
		{
			get
			{
				if(IsTRANSF_SUCURSAL_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transf_sucursal_destino_id;
			}
			set
			{
				_transf_sucursal_destino_idNull = false;
				_transf_sucursal_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSF_SUCURSAL_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSF_SUCURSAL_DESTINO_IDNull
		{
			get { return _transf_sucursal_destino_idNull; }
			set { _transf_sucursal_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSF_SUCURSAL_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSF_SUCURSAL_DESTINO_NOMBRE</c> column value.</value>
		public string TRANSF_SUCURSAL_DESTINO_NOMBRE
		{
			get { return _transf_sucursal_destino_nombre; }
			set { _transf_sucursal_destino_nombre = value; }
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
			dynStr.Append("@CBA@REPARTO_ID=");
			dynStr.Append(REPARTO_ID);
			dynStr.Append("@CBA@CASO_NRO_COMPROBANTE=");
			dynStr.Append(CASO_NRO_COMPROBANTE);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO=");
			dynStr.Append(CASO_ESTADO);
			dynStr.Append("@CBA@CASO_FLUJO_ID=");
			dynStr.Append(CASO_FLUJO_ID);
			dynStr.Append("@CBA@CASO_FLUJO_DESC_IMPR=");
			dynStr.Append(CASO_FLUJO_DESC_IMPR);
			dynStr.Append("@CBA@CASO_FLUJO_DESCRIP=");
			dynStr.Append(CASO_FLUJO_DESCRIP);
			dynStr.Append("@CBA@CASO_SUCURSAL_ID=");
			dynStr.Append(CASO_SUCURSAL_ID);
			dynStr.Append("@CBA@CASO_SUCURSAL_NOMBRE=");
			dynStr.Append(CASO_SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@CASO_SUCURSAL_ABREVIATURA=");
			dynStr.Append(CASO_SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@FECHA_CASO=");
			dynStr.Append(FECHA_CASO);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@PERSONA_DEPARTAMENTO1_NOMBRE=");
			dynStr.Append(PERSONA_DEPARTAMENTO1_NOMBRE);
			dynStr.Append("@CBA@PERSONA_CIUDAD1_NOMBRE=");
			dynStr.Append(PERSONA_CIUDAD1_NOMBRE);
			dynStr.Append("@CBA@PERSONA_BARRIO1_NOMBRE=");
			dynStr.Append(PERSONA_BARRIO1_NOMBRE);
			dynStr.Append("@CBA@PERSONA_CALLE1=");
			dynStr.Append(PERSONA_CALLE1);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ENTREGA_EXITOSA=");
			dynStr.Append(ENTREGA_EXITOSA);
			dynStr.Append("@CBA@BULTOS=");
			dynStr.Append(IsBULTOSNull ? (object)"<NULL>" : BULTOS);
			dynStr.Append("@CBA@TRANSF_SUCURSAL_DESTINO_ID=");
			dynStr.Append(IsTRANSF_SUCURSAL_DESTINO_IDNull ? (object)"<NULL>" : TRANSF_SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@TRANSF_SUCURSAL_DESTINO_NOMBRE=");
			dynStr.Append(TRANSF_SUCURSAL_DESTINO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of REPARTO_DETALLES_INFO_COMPLETARow_Base class
} // End of namespace

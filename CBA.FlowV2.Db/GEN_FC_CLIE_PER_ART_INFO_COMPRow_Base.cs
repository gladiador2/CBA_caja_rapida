// <fileinfo name="GEN_FC_CLIE_PER_ART_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="GEN_FC_CLIE_PER_ART_INFO_COMPRow"/> that 
	/// represents a record in the <c>GEN_FC_CLIE_PER_ART_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="GEN_FC_CLIE_PER_ART_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GEN_FC_CLIE_PER_ART_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _gen_fc_clie_art_id;
		private decimal _articulo_id;
		private string _articulo_codigo;
		private string _articulo_descripcion;
		private string _observacion;
		private decimal _gen_fc_clie_per_id;
		private bool _gen_fc_clie_per_idNull = true;
		private decimal _persona_id;
		private string _persona_codigo;
		private string _persona_nombre;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _precio_unitario;
		private bool _precio_unitarioNull = true;
		private decimal _total;
		private bool _totalNull = true;
		private string _incluir;
		private decimal _impuesto_id;
		private bool _impuesto_idNull = true;
		private string _impuesto_nombre;
		private decimal _porcentaje_dto;
		private bool _porcentaje_dtoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="GEN_FC_CLIE_PER_ART_INFO_COMPRow_Base"/> class.
		/// </summary>
		public GEN_FC_CLIE_PER_ART_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(GEN_FC_CLIE_PER_ART_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.GEN_FC_CLIE_ART_ID != original.GEN_FC_CLIE_ART_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsGEN_FC_CLIE_PER_IDNull != original.IsGEN_FC_CLIE_PER_IDNull) return true;
			if (!this.IsGEN_FC_CLIE_PER_IDNull && !original.IsGEN_FC_CLIE_PER_IDNull)
				if (this.GEN_FC_CLIE_PER_ID != original.GEN_FC_CLIE_PER_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsPRECIO_UNITARIONull != original.IsPRECIO_UNITARIONull) return true;
			if (!this.IsPRECIO_UNITARIONull && !original.IsPRECIO_UNITARIONull)
				if (this.PRECIO_UNITARIO != original.PRECIO_UNITARIO) return true;
			if (this.IsTOTALNull != original.IsTOTALNull) return true;
			if (!this.IsTOTALNull && !original.IsTOTALNull)
				if (this.TOTAL != original.TOTAL) return true;
			if (this.INCLUIR != original.INCLUIR) return true;
			if (this.IsIMPUESTO_IDNull != original.IsIMPUESTO_IDNull) return true;
			if (!this.IsIMPUESTO_IDNull && !original.IsIMPUESTO_IDNull)
				if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IMPUESTO_NOMBRE != original.IMPUESTO_NOMBRE) return true;
			if (this.IsPORCENTAJE_DTONull != original.IsPORCENTAJE_DTONull) return true;
			if (!this.IsPORCENTAJE_DTONull && !original.IsPORCENTAJE_DTONull)
				if (this.PORCENTAJE_DTO != original.PORCENTAJE_DTO) return true;
			
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
		/// Gets or sets the <c>GEN_FC_CLIE_ART_ID</c> column value.
		/// </summary>
		/// <value>The <c>GEN_FC_CLIE_ART_ID</c> column value.</value>
		public decimal GEN_FC_CLIE_ART_ID
		{
			get { return _gen_fc_clie_art_id; }
			set { _gen_fc_clie_art_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CODIGO</c> column value.</value>
		public string ARTICULO_CODIGO
		{
			get { return _articulo_codigo; }
			set { _articulo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DESCRIPCION</c> column value.</value>
		public string ARTICULO_DESCRIPCION
		{
			get { return _articulo_descripcion; }
			set { _articulo_descripcion = value; }
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
		/// Gets or sets the <c>GEN_FC_CLIE_PER_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GEN_FC_CLIE_PER_ID</c> column value.</value>
		public decimal GEN_FC_CLIE_PER_ID
		{
			get
			{
				if(IsGEN_FC_CLIE_PER_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _gen_fc_clie_per_id;
			}
			set
			{
				_gen_fc_clie_per_idNull = false;
				_gen_fc_clie_per_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GEN_FC_CLIE_PER_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGEN_FC_CLIE_PER_IDNull
		{
			get { return _gen_fc_clie_per_idNull; }
			set { _gen_fc_clie_per_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
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
		/// Gets or sets the <c>PRECIO_UNITARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECIO_UNITARIO</c> column value.</value>
		public decimal PRECIO_UNITARIO
		{
			get
			{
				if(IsPRECIO_UNITARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _precio_unitario;
			}
			set
			{
				_precio_unitarioNull = false;
				_precio_unitario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRECIO_UNITARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRECIO_UNITARIONull
		{
			get { return _precio_unitarioNull; }
			set { _precio_unitarioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL</c> column value.</value>
		public decimal TOTAL
		{
			get
			{
				if(IsTOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total;
			}
			set
			{
				_totalNull = false;
				_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTALNull
		{
			get { return _totalNull; }
			set { _totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INCLUIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INCLUIR</c> column value.</value>
		public string INCLUIR
		{
			get { return _incluir; }
			set { _incluir = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get
			{
				if(IsIMPUESTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_id;
			}
			set
			{
				_impuesto_idNull = false;
				_impuesto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_IDNull
		{
			get { return _impuesto_idNull; }
			set { _impuesto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_NOMBRE</c> column value.</value>
		public string IMPUESTO_NOMBRE
		{
			get { return _impuesto_nombre; }
			set { _impuesto_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DTO</c> column value.</value>
		public decimal PORCENTAJE_DTO
		{
			get
			{
				if(IsPORCENTAJE_DTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_dto;
			}
			set
			{
				_porcentaje_dtoNull = false;
				_porcentaje_dto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_DTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_DTONull
		{
			get { return _porcentaje_dtoNull; }
			set { _porcentaje_dtoNull = value; }
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
			dynStr.Append("@CBA@GEN_FC_CLIE_ART_ID=");
			dynStr.Append(GEN_FC_CLIE_ART_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@GEN_FC_CLIE_PER_ID=");
			dynStr.Append(IsGEN_FC_CLIE_PER_IDNull ? (object)"<NULL>" : GEN_FC_CLIE_PER_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@PRECIO_UNITARIO=");
			dynStr.Append(IsPRECIO_UNITARIONull ? (object)"<NULL>" : PRECIO_UNITARIO);
			dynStr.Append("@CBA@TOTAL=");
			dynStr.Append(IsTOTALNull ? (object)"<NULL>" : TOTAL);
			dynStr.Append("@CBA@INCLUIR=");
			dynStr.Append(INCLUIR);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IsIMPUESTO_IDNull ? (object)"<NULL>" : IMPUESTO_ID);
			dynStr.Append("@CBA@IMPUESTO_NOMBRE=");
			dynStr.Append(IMPUESTO_NOMBRE);
			dynStr.Append("@CBA@PORCENTAJE_DTO=");
			dynStr.Append(IsPORCENTAJE_DTONull ? (object)"<NULL>" : PORCENTAJE_DTO);
			return dynStr.ToString();
		}
	} // End of GEN_FC_CLIE_PER_ART_INFO_COMPRow_Base class
} // End of namespace

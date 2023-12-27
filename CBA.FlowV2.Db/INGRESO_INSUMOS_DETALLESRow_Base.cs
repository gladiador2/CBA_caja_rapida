// <fileinfo name="INGRESO_INSUMOS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="INGRESO_INSUMOS_DETALLESRow"/> that 
	/// represents a record in the <c>INGRESO_INSUMOS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="INGRESO_INSUMOS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INGRESO_INSUMOS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _cantidad_bl;
		private bool _cantidad_blNull = true;
		private decimal _cantidad_draft;
		private bool _cantidad_draftNull = true;
		private decimal _cantidad_bascula;
		private bool _cantidad_basculaNull = true;
		private decimal _cantidad_remision;
		private bool _cantidad_remisionNull = true;
		private decimal _box_id;
		private bool _box_idNull = true;
		private decimal _merma;
		private bool _mermaNull = true;
		private string _unidad_id;
		private string _chapa_carreta;
		private string _chapa_camion;
		private string _chofer_documento;
		private string _chofer_nombre;
		private string _nro_ticket_bascula;
		private decimal _ingreso_id;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _usar_cantidad_bl;
		private string _usar_cantidad_draft;
		private string _usar_cantidad_bascula;
		private string _usar_cantidad_remision;
		private decimal _presentacion_id;
		private bool _presentacion_idNull = true;
		private decimal _cantidad_presentacion;
		private bool _cantidad_presentacionNull = true;
		private decimal _cantidad_de_presentacion;
		private bool _cantidad_de_presentacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_INSUMOS_DETALLESRow_Base"/> class.
		/// </summary>
		public INGRESO_INSUMOS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(INGRESO_INSUMOS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.IsCANTIDAD_BLNull != original.IsCANTIDAD_BLNull) return true;
			if (!this.IsCANTIDAD_BLNull && !original.IsCANTIDAD_BLNull)
				if (this.CANTIDAD_BL != original.CANTIDAD_BL) return true;
			if (this.IsCANTIDAD_DRAFTNull != original.IsCANTIDAD_DRAFTNull) return true;
			if (!this.IsCANTIDAD_DRAFTNull && !original.IsCANTIDAD_DRAFTNull)
				if (this.CANTIDAD_DRAFT != original.CANTIDAD_DRAFT) return true;
			if (this.IsCANTIDAD_BASCULANull != original.IsCANTIDAD_BASCULANull) return true;
			if (!this.IsCANTIDAD_BASCULANull && !original.IsCANTIDAD_BASCULANull)
				if (this.CANTIDAD_BASCULA != original.CANTIDAD_BASCULA) return true;
			if (this.IsCANTIDAD_REMISIONNull != original.IsCANTIDAD_REMISIONNull) return true;
			if (!this.IsCANTIDAD_REMISIONNull && !original.IsCANTIDAD_REMISIONNull)
				if (this.CANTIDAD_REMISION != original.CANTIDAD_REMISION) return true;
			if (this.IsBOX_IDNull != original.IsBOX_IDNull) return true;
			if (!this.IsBOX_IDNull && !original.IsBOX_IDNull)
				if (this.BOX_ID != original.BOX_ID) return true;
			if (this.IsMERMANull != original.IsMERMANull) return true;
			if (!this.IsMERMANull && !original.IsMERMANull)
				if (this.MERMA != original.MERMA) return true;
			if (this.UNIDAD_ID != original.UNIDAD_ID) return true;
			if (this.CHAPA_CARRETA != original.CHAPA_CARRETA) return true;
			if (this.CHAPA_CAMION != original.CHAPA_CAMION) return true;
			if (this.CHOFER_DOCUMENTO != original.CHOFER_DOCUMENTO) return true;
			if (this.CHOFER_NOMBRE != original.CHOFER_NOMBRE) return true;
			if (this.NRO_TICKET_BASCULA != original.NRO_TICKET_BASCULA) return true;
			if (this.INGRESO_ID != original.INGRESO_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.USAR_CANTIDAD_BL != original.USAR_CANTIDAD_BL) return true;
			if (this.USAR_CANTIDAD_DRAFT != original.USAR_CANTIDAD_DRAFT) return true;
			if (this.USAR_CANTIDAD_BASCULA != original.USAR_CANTIDAD_BASCULA) return true;
			if (this.USAR_CANTIDAD_REMISION != original.USAR_CANTIDAD_REMISION) return true;
			if (this.IsPRESENTACION_IDNull != original.IsPRESENTACION_IDNull) return true;
			if (!this.IsPRESENTACION_IDNull && !original.IsPRESENTACION_IDNull)
				if (this.PRESENTACION_ID != original.PRESENTACION_ID) return true;
			if (this.IsCANTIDAD_PRESENTACIONNull != original.IsCANTIDAD_PRESENTACIONNull) return true;
			if (!this.IsCANTIDAD_PRESENTACIONNull && !original.IsCANTIDAD_PRESENTACIONNull)
				if (this.CANTIDAD_PRESENTACION != original.CANTIDAD_PRESENTACION) return true;
			if (this.IsCANTIDAD_DE_PRESENTACIONNull != original.IsCANTIDAD_DE_PRESENTACIONNull) return true;
			if (!this.IsCANTIDAD_DE_PRESENTACIONNull && !original.IsCANTIDAD_DE_PRESENTACIONNull)
				if (this.CANTIDAD_DE_PRESENTACION != original.CANTIDAD_DE_PRESENTACION) return true;
			
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get
			{
				if(IsLOTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lote_id;
			}
			set
			{
				_lote_idNull = false;
				_lote_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LOTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLOTE_IDNull
		{
			get { return _lote_idNull; }
			set { _lote_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_BL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_BL</c> column value.</value>
		public decimal CANTIDAD_BL
		{
			get
			{
				if(IsCANTIDAD_BLNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_bl;
			}
			set
			{
				_cantidad_blNull = false;
				_cantidad_bl = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_BL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_BLNull
		{
			get { return _cantidad_blNull; }
			set { _cantidad_blNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_DRAFT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_DRAFT</c> column value.</value>
		public decimal CANTIDAD_DRAFT
		{
			get
			{
				if(IsCANTIDAD_DRAFTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_draft;
			}
			set
			{
				_cantidad_draftNull = false;
				_cantidad_draft = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_DRAFT"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_DRAFTNull
		{
			get { return _cantidad_draftNull; }
			set { _cantidad_draftNull = value; }
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
		/// Gets or sets the <c>CANTIDAD_REMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_REMISION</c> column value.</value>
		public decimal CANTIDAD_REMISION
		{
			get
			{
				if(IsCANTIDAD_REMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_remision;
			}
			set
			{
				_cantidad_remisionNull = false;
				_cantidad_remision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_REMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_REMISIONNull
		{
			get { return _cantidad_remisionNull; }
			set { _cantidad_remisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BOX_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BOX_ID</c> column value.</value>
		public decimal BOX_ID
		{
			get
			{
				if(IsBOX_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _box_id;
			}
			set
			{
				_box_idNull = false;
				_box_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BOX_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBOX_IDNull
		{
			get { return _box_idNull; }
			set { _box_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MERMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERMA</c> column value.</value>
		public decimal MERMA
		{
			get
			{
				if(IsMERMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _merma;
			}
			set
			{
				_mermaNull = false;
				_merma = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MERMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMERMANull
		{
			get { return _mermaNull; }
			set { _mermaNull = value; }
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
		/// Gets or sets the <c>NRO_TICKET_BASCULA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_TICKET_BASCULA</c> column value.</value>
		public string NRO_TICKET_BASCULA
		{
			get { return _nro_ticket_bascula; }
			set { _nro_ticket_bascula = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_ID</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_ID</c> column value.</value>
		public decimal INGRESO_ID
		{
			get { return _ingreso_id; }
			set { _ingreso_id = value; }
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
		/// Gets or sets the <c>USAR_CANTIDAD_BL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USAR_CANTIDAD_BL</c> column value.</value>
		public string USAR_CANTIDAD_BL
		{
			get { return _usar_cantidad_bl; }
			set { _usar_cantidad_bl = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USAR_CANTIDAD_DRAFT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USAR_CANTIDAD_DRAFT</c> column value.</value>
		public string USAR_CANTIDAD_DRAFT
		{
			get { return _usar_cantidad_draft; }
			set { _usar_cantidad_draft = value; }
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
		/// Gets or sets the <c>USAR_CANTIDAD_REMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USAR_CANTIDAD_REMISION</c> column value.</value>
		public string USAR_CANTIDAD_REMISION
		{
			get { return _usar_cantidad_remision; }
			set { _usar_cantidad_remision = value; }
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
		/// Gets or sets the <c>CANTIDAD_DE_PRESENTACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_DE_PRESENTACION</c> column value.</value>
		public decimal CANTIDAD_DE_PRESENTACION
		{
			get
			{
				if(IsCANTIDAD_DE_PRESENTACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_de_presentacion;
			}
			set
			{
				_cantidad_de_presentacionNull = false;
				_cantidad_de_presentacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_DE_PRESENTACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_DE_PRESENTACIONNull
		{
			get { return _cantidad_de_presentacionNull; }
			set { _cantidad_de_presentacionNull = value; }
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
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@CANTIDAD_BL=");
			dynStr.Append(IsCANTIDAD_BLNull ? (object)"<NULL>" : CANTIDAD_BL);
			dynStr.Append("@CBA@CANTIDAD_DRAFT=");
			dynStr.Append(IsCANTIDAD_DRAFTNull ? (object)"<NULL>" : CANTIDAD_DRAFT);
			dynStr.Append("@CBA@CANTIDAD_BASCULA=");
			dynStr.Append(IsCANTIDAD_BASCULANull ? (object)"<NULL>" : CANTIDAD_BASCULA);
			dynStr.Append("@CBA@CANTIDAD_REMISION=");
			dynStr.Append(IsCANTIDAD_REMISIONNull ? (object)"<NULL>" : CANTIDAD_REMISION);
			dynStr.Append("@CBA@BOX_ID=");
			dynStr.Append(IsBOX_IDNull ? (object)"<NULL>" : BOX_ID);
			dynStr.Append("@CBA@MERMA=");
			dynStr.Append(IsMERMANull ? (object)"<NULL>" : MERMA);
			dynStr.Append("@CBA@UNIDAD_ID=");
			dynStr.Append(UNIDAD_ID);
			dynStr.Append("@CBA@CHAPA_CARRETA=");
			dynStr.Append(CHAPA_CARRETA);
			dynStr.Append("@CBA@CHAPA_CAMION=");
			dynStr.Append(CHAPA_CAMION);
			dynStr.Append("@CBA@CHOFER_DOCUMENTO=");
			dynStr.Append(CHOFER_DOCUMENTO);
			dynStr.Append("@CBA@CHOFER_NOMBRE=");
			dynStr.Append(CHOFER_NOMBRE);
			dynStr.Append("@CBA@NRO_TICKET_BASCULA=");
			dynStr.Append(NRO_TICKET_BASCULA);
			dynStr.Append("@CBA@INGRESO_ID=");
			dynStr.Append(INGRESO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@USAR_CANTIDAD_BL=");
			dynStr.Append(USAR_CANTIDAD_BL);
			dynStr.Append("@CBA@USAR_CANTIDAD_DRAFT=");
			dynStr.Append(USAR_CANTIDAD_DRAFT);
			dynStr.Append("@CBA@USAR_CANTIDAD_BASCULA=");
			dynStr.Append(USAR_CANTIDAD_BASCULA);
			dynStr.Append("@CBA@USAR_CANTIDAD_REMISION=");
			dynStr.Append(USAR_CANTIDAD_REMISION);
			dynStr.Append("@CBA@PRESENTACION_ID=");
			dynStr.Append(IsPRESENTACION_IDNull ? (object)"<NULL>" : PRESENTACION_ID);
			dynStr.Append("@CBA@CANTIDAD_PRESENTACION=");
			dynStr.Append(IsCANTIDAD_PRESENTACIONNull ? (object)"<NULL>" : CANTIDAD_PRESENTACION);
			dynStr.Append("@CBA@CANTIDAD_DE_PRESENTACION=");
			dynStr.Append(IsCANTIDAD_DE_PRESENTACIONNull ? (object)"<NULL>" : CANTIDAD_DE_PRESENTACION);
			return dynStr.ToString();
		}
	} // End of INGRESO_INSUMOS_DETALLESRow_Base class
} // End of namespace

// <fileinfo name="TRAMIT_TIP_EST_TRANS_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="TRAMIT_TIP_EST_TRANS_INF_COMPRow"/> that 
	/// represents a record in the <c>TRAMIT_TIP_EST_TRANS_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMIT_TIP_EST_TRANS_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMIT_TIP_EST_TRANS_INF_COMPRow_Base
	{
		private decimal _tramite_tipo_estado_origen_id;
		private bool _tramite_tipo_estado_origen_idNull = true;
		private string _tramite_tipo_estado_origen_nom;
		private decimal _tramite_tipo_etapa_orig_id;
		private bool _tramite_tipo_etapa_orig_idNull = true;
		private string _tramite_tipo_etapa_orig_nombre;
		private decimal _tramite_tipo_estado_destino_id;
		private bool _tramite_tipo_estado_destino_idNull = true;
		private string _tramites_tipos_estad_dest_nom;
		private decimal _tramite_tipo_etapa_dest_id;
		private bool _tramite_tipo_etapa_dest_idNull = true;
		private string _tramite_tipo_etapa_dest_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMIT_TIP_EST_TRANS_INF_COMPRow_Base"/> class.
		/// </summary>
		public TRAMIT_TIP_EST_TRANS_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMIT_TIP_EST_TRANS_INF_COMPRow_Base original)
		{
			if (this.IsTRAMITE_TIPO_ESTADO_ORIGEN_IDNull != original.IsTRAMITE_TIPO_ESTADO_ORIGEN_IDNull) return true;
			if (!this.IsTRAMITE_TIPO_ESTADO_ORIGEN_IDNull && !original.IsTRAMITE_TIPO_ESTADO_ORIGEN_IDNull)
				if (this.TRAMITE_TIPO_ESTADO_ORIGEN_ID != original.TRAMITE_TIPO_ESTADO_ORIGEN_ID) return true;
			if (this.TRAMITE_TIPO_ESTADO_ORIGEN_NOM != original.TRAMITE_TIPO_ESTADO_ORIGEN_NOM) return true;
			if (this.IsTRAMITE_TIPO_ETAPA_ORIG_IDNull != original.IsTRAMITE_TIPO_ETAPA_ORIG_IDNull) return true;
			if (!this.IsTRAMITE_TIPO_ETAPA_ORIG_IDNull && !original.IsTRAMITE_TIPO_ETAPA_ORIG_IDNull)
				if (this.TRAMITE_TIPO_ETAPA_ORIG_ID != original.TRAMITE_TIPO_ETAPA_ORIG_ID) return true;
			if (this.TRAMITE_TIPO_ETAPA_ORIG_NOMBRE != original.TRAMITE_TIPO_ETAPA_ORIG_NOMBRE) return true;
			if (this.IsTRAMITE_TIPO_ESTADO_DESTINO_IDNull != original.IsTRAMITE_TIPO_ESTADO_DESTINO_IDNull) return true;
			if (!this.IsTRAMITE_TIPO_ESTADO_DESTINO_IDNull && !original.IsTRAMITE_TIPO_ESTADO_DESTINO_IDNull)
				if (this.TRAMITE_TIPO_ESTADO_DESTINO_ID != original.TRAMITE_TIPO_ESTADO_DESTINO_ID) return true;
			if (this.TRAMITES_TIPOS_ESTAD_DEST_NOM != original.TRAMITES_TIPOS_ESTAD_DEST_NOM) return true;
			if (this.IsTRAMITE_TIPO_ETAPA_DEST_IDNull != original.IsTRAMITE_TIPO_ETAPA_DEST_IDNull) return true;
			if (!this.IsTRAMITE_TIPO_ETAPA_DEST_IDNull && !original.IsTRAMITE_TIPO_ETAPA_DEST_IDNull)
				if (this.TRAMITE_TIPO_ETAPA_DEST_ID != original.TRAMITE_TIPO_ETAPA_DEST_ID) return true;
			if (this.TRAMITE_TIPO_ETAPA_DEST_NOMBRE != original.TRAMITE_TIPO_ETAPA_DEST_NOMBRE) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ESTADO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ESTADO_ORIGEN_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ESTADO_ORIGEN_ID
		{
			get
			{
				if(IsTRAMITE_TIPO_ESTADO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramite_tipo_estado_origen_id;
			}
			set
			{
				_tramite_tipo_estado_origen_idNull = false;
				_tramite_tipo_estado_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITE_TIPO_ESTADO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITE_TIPO_ESTADO_ORIGEN_IDNull
		{
			get { return _tramite_tipo_estado_origen_idNull; }
			set { _tramite_tipo_estado_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ESTADO_ORIGEN_NOM</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ESTADO_ORIGEN_NOM</c> column value.</value>
		public string TRAMITE_TIPO_ESTADO_ORIGEN_NOM
		{
			get { return _tramite_tipo_estado_origen_nom; }
			set { _tramite_tipo_estado_origen_nom = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_ORIG_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_ORIG_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ETAPA_ORIG_ID
		{
			get
			{
				if(IsTRAMITE_TIPO_ETAPA_ORIG_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramite_tipo_etapa_orig_id;
			}
			set
			{
				_tramite_tipo_etapa_orig_idNull = false;
				_tramite_tipo_etapa_orig_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITE_TIPO_ETAPA_ORIG_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITE_TIPO_ETAPA_ORIG_IDNull
		{
			get { return _tramite_tipo_etapa_orig_idNull; }
			set { _tramite_tipo_etapa_orig_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_ORIG_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_ORIG_NOMBRE</c> column value.</value>
		public string TRAMITE_TIPO_ETAPA_ORIG_NOMBRE
		{
			get { return _tramite_tipo_etapa_orig_nombre; }
			set { _tramite_tipo_etapa_orig_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ESTADO_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ESTADO_DESTINO_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ESTADO_DESTINO_ID
		{
			get
			{
				if(IsTRAMITE_TIPO_ESTADO_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramite_tipo_estado_destino_id;
			}
			set
			{
				_tramite_tipo_estado_destino_idNull = false;
				_tramite_tipo_estado_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITE_TIPO_ESTADO_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITE_TIPO_ESTADO_DESTINO_IDNull
		{
			get { return _tramite_tipo_estado_destino_idNull; }
			set { _tramite_tipo_estado_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITES_TIPOS_ESTAD_DEST_NOM</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITES_TIPOS_ESTAD_DEST_NOM</c> column value.</value>
		public string TRAMITES_TIPOS_ESTAD_DEST_NOM
		{
			get { return _tramites_tipos_estad_dest_nom; }
			set { _tramites_tipos_estad_dest_nom = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_DEST_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_DEST_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ETAPA_DEST_ID
		{
			get
			{
				if(IsTRAMITE_TIPO_ETAPA_DEST_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramite_tipo_etapa_dest_id;
			}
			set
			{
				_tramite_tipo_etapa_dest_idNull = false;
				_tramite_tipo_etapa_dest_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITE_TIPO_ETAPA_DEST_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITE_TIPO_ETAPA_DEST_IDNull
		{
			get { return _tramite_tipo_etapa_dest_idNull; }
			set { _tramite_tipo_etapa_dest_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_DEST_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_DEST_NOMBRE</c> column value.</value>
		public string TRAMITE_TIPO_ETAPA_DEST_NOMBRE
		{
			get { return _tramite_tipo_etapa_dest_nombre; }
			set { _tramite_tipo_etapa_dest_nombre = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@TRAMITE_TIPO_ESTADO_ORIGEN_ID=");
			dynStr.Append(IsTRAMITE_TIPO_ESTADO_ORIGEN_IDNull ? (object)"<NULL>" : TRAMITE_TIPO_ESTADO_ORIGEN_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_ESTADO_ORIGEN_NOM=");
			dynStr.Append(TRAMITE_TIPO_ESTADO_ORIGEN_NOM);
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_ORIG_ID=");
			dynStr.Append(IsTRAMITE_TIPO_ETAPA_ORIG_IDNull ? (object)"<NULL>" : TRAMITE_TIPO_ETAPA_ORIG_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_ORIG_NOMBRE=");
			dynStr.Append(TRAMITE_TIPO_ETAPA_ORIG_NOMBRE);
			dynStr.Append("@CBA@TRAMITE_TIPO_ESTADO_DESTINO_ID=");
			dynStr.Append(IsTRAMITE_TIPO_ESTADO_DESTINO_IDNull ? (object)"<NULL>" : TRAMITE_TIPO_ESTADO_DESTINO_ID);
			dynStr.Append("@CBA@TRAMITES_TIPOS_ESTAD_DEST_NOM=");
			dynStr.Append(TRAMITES_TIPOS_ESTAD_DEST_NOM);
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_DEST_ID=");
			dynStr.Append(IsTRAMITE_TIPO_ETAPA_DEST_IDNull ? (object)"<NULL>" : TRAMITE_TIPO_ETAPA_DEST_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_DEST_NOMBRE=");
			dynStr.Append(TRAMITE_TIPO_ETAPA_DEST_NOMBRE);
			return dynStr.ToString();
		}
	} // End of TRAMIT_TIP_EST_TRANS_INF_COMPRow_Base class
} // End of namespace

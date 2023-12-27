// <fileinfo name="TRANSFERENCIA_CAJAS_SUCURSALRow_Base.cs">
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
	/// The base class for <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> that 
	/// represents a record in the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSFERENCIA_CAJAS_SUCURSALRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _caja_suc_origen_id;
		private bool _caja_suc_origen_idNull = true;
		private decimal _caja_suc_des_id;
		private bool _caja_suc_des_idNull = true;
		private decimal _fondo_fijo_origen_id;
		private bool _fondo_fijo_origen_idNull = true;
		private decimal _fondo_fijo_des_id;
		private bool _fondo_fijo_des_idNull = true;
		private System.DateTime _fecha;
		private decimal _usuario_id;
		private decimal _sucursal_origen_id;
		private decimal _sucursal_destino_id;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private decimal _caja_teso_origen_id;
		private bool _caja_teso_origen_idNull = true;
		private decimal _caja_teso_destino_id;
		private bool _caja_teso_destino_idNull = true;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow_Base"/> class.
		/// </summary>
		public TRANSFERENCIA_CAJAS_SUCURSALRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSFERENCIA_CAJAS_SUCURSALRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsCAJA_SUC_ORIGEN_IDNull != original.IsCAJA_SUC_ORIGEN_IDNull) return true;
			if (!this.IsCAJA_SUC_ORIGEN_IDNull && !original.IsCAJA_SUC_ORIGEN_IDNull)
				if (this.CAJA_SUC_ORIGEN_ID != original.CAJA_SUC_ORIGEN_ID) return true;
			if (this.IsCAJA_SUC_DES_IDNull != original.IsCAJA_SUC_DES_IDNull) return true;
			if (!this.IsCAJA_SUC_DES_IDNull && !original.IsCAJA_SUC_DES_IDNull)
				if (this.CAJA_SUC_DES_ID != original.CAJA_SUC_DES_ID) return true;
			if (this.IsFONDO_FIJO_ORIGEN_IDNull != original.IsFONDO_FIJO_ORIGEN_IDNull) return true;
			if (!this.IsFONDO_FIJO_ORIGEN_IDNull && !original.IsFONDO_FIJO_ORIGEN_IDNull)
				if (this.FONDO_FIJO_ORIGEN_ID != original.FONDO_FIJO_ORIGEN_ID) return true;
			if (this.IsFONDO_FIJO_DES_IDNull != original.IsFONDO_FIJO_DES_IDNull) return true;
			if (!this.IsFONDO_FIJO_DES_IDNull && !original.IsFONDO_FIJO_DES_IDNull)
				if (this.FONDO_FIJO_DES_ID != original.FONDO_FIJO_DES_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.SUCURSAL_ORIGEN_ID != original.SUCURSAL_ORIGEN_ID) return true;
			if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.IsCAJA_TESO_ORIGEN_IDNull != original.IsCAJA_TESO_ORIGEN_IDNull) return true;
			if (!this.IsCAJA_TESO_ORIGEN_IDNull && !original.IsCAJA_TESO_ORIGEN_IDNull)
				if (this.CAJA_TESO_ORIGEN_ID != original.CAJA_TESO_ORIGEN_ID) return true;
			if (this.IsCAJA_TESO_DESTINO_IDNull != original.IsCAJA_TESO_DESTINO_IDNull) return true;
			if (!this.IsCAJA_TESO_DESTINO_IDNull && !original.IsCAJA_TESO_DESTINO_IDNull)
				if (this.CAJA_TESO_DESTINO_ID != original.CAJA_TESO_DESTINO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_SUC_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAJA_SUC_ORIGEN_ID</c> column value.</value>
		public decimal CAJA_SUC_ORIGEN_ID
		{
			get
			{
				if(IsCAJA_SUC_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caja_suc_origen_id;
			}
			set
			{
				_caja_suc_origen_idNull = false;
				_caja_suc_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAJA_SUC_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAJA_SUC_ORIGEN_IDNull
		{
			get { return _caja_suc_origen_idNull; }
			set { _caja_suc_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_SUC_DES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAJA_SUC_DES_ID</c> column value.</value>
		public decimal CAJA_SUC_DES_ID
		{
			get
			{
				if(IsCAJA_SUC_DES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caja_suc_des_id;
			}
			set
			{
				_caja_suc_des_idNull = false;
				_caja_suc_des_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAJA_SUC_DES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAJA_SUC_DES_IDNull
		{
			get { return _caja_suc_des_idNull; }
			set { _caja_suc_des_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FONDO_FIJO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FONDO_FIJO_ORIGEN_ID</c> column value.</value>
		public decimal FONDO_FIJO_ORIGEN_ID
		{
			get
			{
				if(IsFONDO_FIJO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fondo_fijo_origen_id;
			}
			set
			{
				_fondo_fijo_origen_idNull = false;
				_fondo_fijo_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FONDO_FIJO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFONDO_FIJO_ORIGEN_IDNull
		{
			get { return _fondo_fijo_origen_idNull; }
			set { _fondo_fijo_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FONDO_FIJO_DES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FONDO_FIJO_DES_ID</c> column value.</value>
		public decimal FONDO_FIJO_DES_ID
		{
			get
			{
				if(IsFONDO_FIJO_DES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fondo_fijo_des_id;
			}
			set
			{
				_fondo_fijo_des_idNull = false;
				_fondo_fijo_des_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FONDO_FIJO_DES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFONDO_FIJO_DES_IDNull
		{
			get { return _fondo_fijo_des_idNull; }
			set { _fondo_fijo_des_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ID</c> column value.</value>
		public decimal SUCURSAL_ORIGEN_ID
		{
			get { return _sucursal_origen_id; }
			set { _sucursal_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ID</c> column value.</value>
		public decimal SUCURSAL_DESTINO_ID
		{
			get { return _sucursal_destino_id; }
			set { _sucursal_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_TESO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAJA_TESO_ORIGEN_ID</c> column value.</value>
		public decimal CAJA_TESO_ORIGEN_ID
		{
			get
			{
				if(IsCAJA_TESO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caja_teso_origen_id;
			}
			set
			{
				_caja_teso_origen_idNull = false;
				_caja_teso_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAJA_TESO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAJA_TESO_ORIGEN_IDNull
		{
			get { return _caja_teso_origen_idNull; }
			set { _caja_teso_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_TESO_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAJA_TESO_DESTINO_ID</c> column value.</value>
		public decimal CAJA_TESO_DESTINO_ID
		{
			get
			{
				if(IsCAJA_TESO_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caja_teso_destino_id;
			}
			set
			{
				_caja_teso_destino_idNull = false;
				_caja_teso_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAJA_TESO_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAJA_TESO_DESTINO_IDNull
		{
			get { return _caja_teso_destino_idNull; }
			set { _caja_teso_destino_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CAJA_SUC_ORIGEN_ID=");
			dynStr.Append(IsCAJA_SUC_ORIGEN_IDNull ? (object)"<NULL>" : CAJA_SUC_ORIGEN_ID);
			dynStr.Append("@CBA@CAJA_SUC_DES_ID=");
			dynStr.Append(IsCAJA_SUC_DES_IDNull ? (object)"<NULL>" : CAJA_SUC_DES_ID);
			dynStr.Append("@CBA@FONDO_FIJO_ORIGEN_ID=");
			dynStr.Append(IsFONDO_FIJO_ORIGEN_IDNull ? (object)"<NULL>" : FONDO_FIJO_ORIGEN_ID);
			dynStr.Append("@CBA@FONDO_FIJO_DES_ID=");
			dynStr.Append(IsFONDO_FIJO_DES_IDNull ? (object)"<NULL>" : FONDO_FIJO_DES_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ID=");
			dynStr.Append(SUCURSAL_ORIGEN_ID);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@CAJA_TESO_ORIGEN_ID=");
			dynStr.Append(IsCAJA_TESO_ORIGEN_IDNull ? (object)"<NULL>" : CAJA_TESO_ORIGEN_ID);
			dynStr.Append("@CBA@CAJA_TESO_DESTINO_ID=");
			dynStr.Append(IsCAJA_TESO_DESTINO_IDNull ? (object)"<NULL>" : CAJA_TESO_DESTINO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of TRANSFERENCIA_CAJAS_SUCURSALRow_Base class
} // End of namespace

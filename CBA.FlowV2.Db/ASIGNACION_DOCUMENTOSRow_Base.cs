// <fileinfo name="ASIGNACION_DOCUMENTOSRow_Base.cs">
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
	/// The base class for <see cref="ASIGNACION_DOCUMENTOSRow"/> that 
	/// represents a record in the <c>ASIGNACION_DOCUMENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ASIGNACION_DOCUMENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ASIGNACION_DOCUMENTOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _ctacte_pagare_id;
		private bool _ctacte_pagare_idNull = true;
		private System.DateTime _fecha_inicio;
		private decimal _texto_predefinido_inicio_id;
		private bool _texto_predefinido_inicio_idNull = true;
		private string _observacion_inicio;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private decimal _texto_predefinido_fin_id;
		private bool _texto_predefinido_fin_idNull = true;
		private string _observacion_fin;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private decimal _ctacte_banco_id;
		private bool _ctacte_banco_idNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private System.DateTime _fecha_creacion;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private string _existe_asignacion_posterior;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ASIGNACION_DOCUMENTOSRow_Base"/> class.
		/// </summary>
		public ASIGNACION_DOCUMENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ASIGNACION_DOCUMENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsCTACTE_PAGARE_IDNull != original.IsCTACTE_PAGARE_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_IDNull && !original.IsCTACTE_PAGARE_IDNull)
				if (this.CTACTE_PAGARE_ID != original.CTACTE_PAGARE_ID) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsTEXTO_PREDEFINIDO_INICIO_IDNull != original.IsTEXTO_PREDEFINIDO_INICIO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_INICIO_IDNull && !original.IsTEXTO_PREDEFINIDO_INICIO_IDNull)
				if (this.TEXTO_PREDEFINIDO_INICIO_ID != original.TEXTO_PREDEFINIDO_INICIO_ID) return true;
			if (this.OBSERVACION_INICIO != original.OBSERVACION_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.IsTEXTO_PREDEFINIDO_FIN_IDNull != original.IsTEXTO_PREDEFINIDO_FIN_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_FIN_IDNull && !original.IsTEXTO_PREDEFINIDO_FIN_IDNull)
				if (this.TEXTO_PREDEFINIDO_FIN_ID != original.TEXTO_PREDEFINIDO_FIN_ID) return true;
			if (this.OBSERVACION_FIN != original.OBSERVACION_FIN) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsCTACTE_BANCO_IDNull != original.IsCTACTE_BANCO_IDNull) return true;
			if (!this.IsCTACTE_BANCO_IDNull && !original.IsCTACTE_BANCO_IDNull)
				if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.EXISTE_ASIGNACION_POSTERIOR != original.EXISTE_ASIGNACION_POSTERIOR) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_ID
		{
			get
			{
				if(IsCTACTE_PAGARE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagare_id;
			}
			set
			{
				_ctacte_pagare_idNull = false;
				_ctacte_pagare_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGARE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGARE_IDNull
		{
			get { return _ctacte_pagare_idNull; }
			set { _ctacte_pagare_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get { return _fecha_inicio; }
			set { _fecha_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_INICIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_INICIO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_INICIO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_INICIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_inicio_id;
			}
			set
			{
				_texto_predefinido_inicio_idNull = false;
				_texto_predefinido_inicio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_INICIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_INICIO_IDNull
		{
			get { return _texto_predefinido_inicio_idNull; }
			set { _texto_predefinido_inicio_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_INICIO</c> column value.</value>
		public string OBSERVACION_INICIO
		{
			get { return _observacion_inicio; }
			set { _observacion_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_FIN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_FIN_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_FIN_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_FIN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_fin_id;
			}
			set
			{
				_texto_predefinido_fin_idNull = false;
				_texto_predefinido_fin_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_FIN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_FIN_IDNull
		{
			get { return _texto_predefinido_fin_idNull; }
			set { _texto_predefinido_fin_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_FIN</c> column value.</value>
		public string OBSERVACION_FIN
		{
			get { return _observacion_fin; }
			set { _observacion_fin = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ID
		{
			get
			{
				if(IsCTACTE_BANCO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_banco_id;
			}
			set
			{
				_ctacte_banco_idNull = false;
				_ctacte_banco_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCO_IDNull
		{
			get { return _ctacte_banco_idNull; }
			set { _ctacte_banco_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get
			{
				if(IsUSUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id;
			}
			set
			{
				_usuario_idNull = false;
				_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_IDNull
		{
			get { return _usuario_idNull; }
			set { _usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_RECIBIDO_ID
		{
			get
			{
				if(IsCTACTE_CHEQUE_RECIBIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_cheque_recibido_id;
			}
			set
			{
				_ctacte_cheque_recibido_idNull = false;
				_ctacte_cheque_recibido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CHEQUE_RECIBIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CHEQUE_RECIBIDO_IDNull
		{
			get { return _ctacte_cheque_recibido_idNull; }
			set { _ctacte_cheque_recibido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXISTE_ASIGNACION_POSTERIOR</c> column value.
		/// </summary>
		/// <value>The <c>EXISTE_ASIGNACION_POSTERIOR</c> column value.</value>
		public string EXISTE_ASIGNACION_POSTERIOR
		{
			get { return _existe_asignacion_posterior; }
			set { _existe_asignacion_posterior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_id;
			}
			set
			{
				_ctacte_persona_idNull = false;
				_ctacte_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_IDNull
		{
			get { return _ctacte_persona_idNull; }
			set { _ctacte_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_ID</c> column value.</value>
		public decimal ACTIVO_ID
		{
			get
			{
				if(IsACTIVO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _activo_id;
			}
			set
			{
				_activo_idNull = false;
				_activo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACTIVO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACTIVO_IDNull
		{
			get { return _activo_idNull; }
			set { _activo_idNull = value; }
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
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@CTACTE_PAGARE_ID=");
			dynStr.Append(IsCTACTE_PAGARE_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_ID);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_INICIO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_INICIO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_INICIO_ID);
			dynStr.Append("@CBA@OBSERVACION_INICIO=");
			dynStr.Append(OBSERVACION_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_FIN_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_FIN_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_FIN_ID);
			dynStr.Append("@CBA@OBSERVACION_FIN=");
			dynStr.Append(OBSERVACION_FIN);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(IsCTACTE_BANCO_IDNull ? (object)"<NULL>" : CTACTE_BANCO_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@EXISTE_ASIGNACION_POSTERIOR=");
			dynStr.Append(EXISTE_ASIGNACION_POSTERIOR);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ASIGNACION_DOCUMENTOSRow_Base class
} // End of namespace

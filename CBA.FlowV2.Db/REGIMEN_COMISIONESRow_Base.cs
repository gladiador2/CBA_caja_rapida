// <fileinfo name="REGIMEN_COMISIONESRow_Base.cs">
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
	/// The base class for <see cref="REGIMEN_COMISIONESRow"/> that 
	/// represents a record in the <c>REGIMEN_COMISIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REGIMEN_COMISIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REGIMEN_COMISIONESRow_Base
	{
		private decimal _id;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private decimal _subgrupo_id;
		private bool _subgrupo_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _lista_precios_id;
		private bool _lista_precios_idNull = true;
		private decimal _descuento_maximo;
		private bool _descuento_maximoNull = true;
		private decimal _cantidad_minima;
		private bool _cantidad_minimaNull = true;
		private System.DateTime _fecha_desde;
		private bool _fecha_desdeNull = true;
		private System.DateTime _fecha_hasta;
		private bool _fecha_hastaNull = true;
		private decimal _porcentaje_comision;
		private string _estado;
		private decimal _persona_id;
		private bool _persona_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="REGIMEN_COMISIONESRow_Base"/> class.
		/// </summary>
		public REGIMEN_COMISIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REGIMEN_COMISIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.IsSUBGRUPO_IDNull != original.IsSUBGRUPO_IDNull) return true;
			if (!this.IsSUBGRUPO_IDNull && !original.IsSUBGRUPO_IDNull)
				if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsLISTA_PRECIOS_IDNull != original.IsLISTA_PRECIOS_IDNull) return true;
			if (!this.IsLISTA_PRECIOS_IDNull && !original.IsLISTA_PRECIOS_IDNull)
				if (this.LISTA_PRECIOS_ID != original.LISTA_PRECIOS_ID) return true;
			if (this.IsDESCUENTO_MAXIMONull != original.IsDESCUENTO_MAXIMONull) return true;
			if (!this.IsDESCUENTO_MAXIMONull && !original.IsDESCUENTO_MAXIMONull)
				if (this.DESCUENTO_MAXIMO != original.DESCUENTO_MAXIMO) return true;
			if (this.IsCANTIDAD_MINIMANull != original.IsCANTIDAD_MINIMANull) return true;
			if (!this.IsCANTIDAD_MINIMANull && !original.IsCANTIDAD_MINIMANull)
				if (this.CANTIDAD_MINIMA != original.CANTIDAD_MINIMA) return true;
			if (this.IsFECHA_DESDENull != original.IsFECHA_DESDENull) return true;
			if (!this.IsFECHA_DESDENull && !original.IsFECHA_DESDENull)
				if (this.FECHA_DESDE != original.FECHA_DESDE) return true;
			if (this.IsFECHA_HASTANull != original.IsFECHA_HASTANull) return true;
			if (!this.IsFECHA_HASTANull && !original.IsFECHA_HASTANull)
				if (this.FECHA_HASTA != original.FECHA_HASTA) return true;
			if (this.PORCENTAJE_COMISION != original.PORCENTAJE_COMISION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			
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
		/// Gets or sets the <c>FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_ID</c> column value.</value>
		public decimal FAMILIA_ID
		{
			get
			{
				if(IsFAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _familia_id;
			}
			set
			{
				_familia_idNull = false;
				_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFAMILIA_IDNull
		{
			get { return _familia_idNull; }
			set { _familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public decimal GRUPO_ID
		{
			get
			{
				if(IsGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_id;
			}
			set
			{
				_grupo_idNull = false;
				_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_IDNull
		{
			get { return _grupo_idNull; }
			set { _grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_ID</c> column value.</value>
		public decimal SUBGRUPO_ID
		{
			get
			{
				if(IsSUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _subgrupo_id;
			}
			set
			{
				_subgrupo_idNull = false;
				_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUBGRUPO_IDNull
		{
			get { return _subgrupo_idNull; }
			set { _subgrupo_idNull = value; }
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
		/// Gets or sets the <c>LISTA_PRECIOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIOS_ID</c> column value.</value>
		public decimal LISTA_PRECIOS_ID
		{
			get
			{
				if(IsLISTA_PRECIOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lista_precios_id;
			}
			set
			{
				_lista_precios_idNull = false;
				_lista_precios_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LISTA_PRECIOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLISTA_PRECIOS_IDNull
		{
			get { return _lista_precios_idNull; }
			set { _lista_precios_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_MAXIMO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_MAXIMO</c> column value.</value>
		public decimal DESCUENTO_MAXIMO
		{
			get
			{
				if(IsDESCUENTO_MAXIMONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_maximo;
			}
			set
			{
				_descuento_maximoNull = false;
				_descuento_maximo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_MAXIMO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_MAXIMONull
		{
			get { return _descuento_maximoNull; }
			set { _descuento_maximoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MINIMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MINIMA</c> column value.</value>
		public decimal CANTIDAD_MINIMA
		{
			get
			{
				if(IsCANTIDAD_MINIMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_minima;
			}
			set
			{
				_cantidad_minimaNull = false;
				_cantidad_minima = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MINIMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MINIMANull
		{
			get { return _cantidad_minimaNull; }
			set { _cantidad_minimaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESDE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESDE</c> column value.</value>
		public System.DateTime FECHA_DESDE
		{
			get
			{
				if(IsFECHA_DESDENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desde;
			}
			set
			{
				_fecha_desdeNull = false;
				_fecha_desde = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESDE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESDENull
		{
			get { return _fecha_desdeNull; }
			set { _fecha_desdeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_HASTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_HASTA</c> column value.</value>
		public System.DateTime FECHA_HASTA
		{
			get
			{
				if(IsFECHA_HASTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_hasta;
			}
			set
			{
				_fecha_hastaNull = false;
				_fecha_hasta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_HASTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_HASTANull
		{
			get { return _fecha_hastaNull; }
			set { _fecha_hastaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_COMISION</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_COMISION</c> column value.</value>
		public decimal PORCENTAJE_COMISION
		{
			get { return _porcentaje_comision; }
			set { _porcentaje_comision = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(IsSUBGRUPO_IDNull ? (object)"<NULL>" : SUBGRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@LISTA_PRECIOS_ID=");
			dynStr.Append(IsLISTA_PRECIOS_IDNull ? (object)"<NULL>" : LISTA_PRECIOS_ID);
			dynStr.Append("@CBA@DESCUENTO_MAXIMO=");
			dynStr.Append(IsDESCUENTO_MAXIMONull ? (object)"<NULL>" : DESCUENTO_MAXIMO);
			dynStr.Append("@CBA@CANTIDAD_MINIMA=");
			dynStr.Append(IsCANTIDAD_MINIMANull ? (object)"<NULL>" : CANTIDAD_MINIMA);
			dynStr.Append("@CBA@FECHA_DESDE=");
			dynStr.Append(IsFECHA_DESDENull ? (object)"<NULL>" : FECHA_DESDE);
			dynStr.Append("@CBA@FECHA_HASTA=");
			dynStr.Append(IsFECHA_HASTANull ? (object)"<NULL>" : FECHA_HASTA);
			dynStr.Append("@CBA@PORCENTAJE_COMISION=");
			dynStr.Append(PORCENTAJE_COMISION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			return dynStr.ToString();
		}
	} // End of REGIMEN_COMISIONESRow_Base class
} // End of namespace

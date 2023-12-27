// <fileinfo name="RETENCION_ARTIC_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> that 
	/// represents a record in the <c>RETENCION_ARTIC_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="RETENCION_ARTIC_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RETENCION_ARTIC_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _porcentaje;
		private decimal _articulo_id;
		private string _codigo_empresa;
		private string _codigo_barras_empresa;
		private string _descripcion_interna;
		private string _descripcion_impresion;
		private string _unidad_medida_id;
		private decimal _cantidad_minima;
		private bool _cantidad_minimaNull = true;
		private decimal _cantidad_maxima;
		private bool _cantidad_maximaNull = true;
		private decimal _cantidad_mayorista;
		private bool _cantidad_mayoristaNull = true;
		private string _unidad_medida_control;

		/// <summary>
		/// Initializes a new instance of the <see cref="RETENCION_ARTIC_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public RETENCION_ARTIC_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(RETENCION_ARTIC_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.CODIGO_EMPRESA != original.CODIGO_EMPRESA) return true;
			if (this.CODIGO_BARRAS_EMPRESA != original.CODIGO_BARRAS_EMPRESA) return true;
			if (this.DESCRIPCION_INTERNA != original.DESCRIPCION_INTERNA) return true;
			if (this.DESCRIPCION_IMPRESION != original.DESCRIPCION_IMPRESION) return true;
			if (this.UNIDAD_MEDIDA_ID != original.UNIDAD_MEDIDA_ID) return true;
			if (this.IsCANTIDAD_MINIMANull != original.IsCANTIDAD_MINIMANull) return true;
			if (!this.IsCANTIDAD_MINIMANull && !original.IsCANTIDAD_MINIMANull)
				if (this.CANTIDAD_MINIMA != original.CANTIDAD_MINIMA) return true;
			if (this.IsCANTIDAD_MAXIMANull != original.IsCANTIDAD_MAXIMANull) return true;
			if (!this.IsCANTIDAD_MAXIMANull && !original.IsCANTIDAD_MAXIMANull)
				if (this.CANTIDAD_MAXIMA != original.CANTIDAD_MAXIMA) return true;
			if (this.IsCANTIDAD_MAYORISTANull != original.IsCANTIDAD_MAYORISTANull) return true;
			if (!this.IsCANTIDAD_MAYORISTANull && !original.IsCANTIDAD_MAYORISTANull)
				if (this.CANTIDAD_MAYORISTA != original.CANTIDAD_MAYORISTA) return true;
			if (this.UNIDAD_MEDIDA_CONTROL != original.UNIDAD_MEDIDA_CONTROL) return true;
			
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
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get { return _porcentaje; }
			set { _porcentaje = value; }
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
		/// Gets or sets the <c>CODIGO_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_EMPRESA</c> column value.</value>
		public string CODIGO_EMPRESA
		{
			get { return _codigo_empresa; }
			set { _codigo_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_BARRAS_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_BARRAS_EMPRESA</c> column value.</value>
		public string CODIGO_BARRAS_EMPRESA
		{
			get { return _codigo_barras_empresa; }
			set { _codigo_barras_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_INTERNA</c> column value.</value>
		public string DESCRIPCION_INTERNA
		{
			get { return _descripcion_interna; }
			set { _descripcion_interna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_IMPRESION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_IMPRESION</c> column value.</value>
		public string DESCRIPCION_IMPRESION
		{
			get { return _descripcion_impresion; }
			set { _descripcion_impresion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ID
		{
			get { return _unidad_medida_id; }
			set { _unidad_medida_id = value; }
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
		/// Gets or sets the <c>CANTIDAD_MAXIMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MAXIMA</c> column value.</value>
		public decimal CANTIDAD_MAXIMA
		{
			get
			{
				if(IsCANTIDAD_MAXIMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_maxima;
			}
			set
			{
				_cantidad_maximaNull = false;
				_cantidad_maxima = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MAXIMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MAXIMANull
		{
			get { return _cantidad_maximaNull; }
			set { _cantidad_maximaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MAYORISTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MAYORISTA</c> column value.</value>
		public decimal CANTIDAD_MAYORISTA
		{
			get
			{
				if(IsCANTIDAD_MAYORISTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_mayorista;
			}
			set
			{
				_cantidad_mayoristaNull = false;
				_cantidad_mayorista = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MAYORISTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MAYORISTANull
		{
			get { return _cantidad_mayoristaNull; }
			set { _cantidad_mayoristaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_CONTROL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_CONTROL</c> column value.</value>
		public string UNIDAD_MEDIDA_CONTROL
		{
			get { return _unidad_medida_control; }
			set { _unidad_medida_control = value; }
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
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(PORCENTAJE);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@CODIGO_EMPRESA=");
			dynStr.Append(CODIGO_EMPRESA);
			dynStr.Append("@CBA@CODIGO_BARRAS_EMPRESA=");
			dynStr.Append(CODIGO_BARRAS_EMPRESA);
			dynStr.Append("@CBA@DESCRIPCION_INTERNA=");
			dynStr.Append(DESCRIPCION_INTERNA);
			dynStr.Append("@CBA@DESCRIPCION_IMPRESION=");
			dynStr.Append(DESCRIPCION_IMPRESION);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@CANTIDAD_MINIMA=");
			dynStr.Append(IsCANTIDAD_MINIMANull ? (object)"<NULL>" : CANTIDAD_MINIMA);
			dynStr.Append("@CBA@CANTIDAD_MAXIMA=");
			dynStr.Append(IsCANTIDAD_MAXIMANull ? (object)"<NULL>" : CANTIDAD_MAXIMA);
			dynStr.Append("@CBA@CANTIDAD_MAYORISTA=");
			dynStr.Append(IsCANTIDAD_MAYORISTANull ? (object)"<NULL>" : CANTIDAD_MAYORISTA);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_CONTROL=");
			dynStr.Append(UNIDAD_MEDIDA_CONTROL);
			return dynStr.ToString();
		}
	} // End of RETENCION_ARTIC_INFO_COMPLRow_Base class
} // End of namespace

// <fileinfo name="REPORTES_PARAMETROSRow_Base.cs">
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
	/// The base class for <see cref="REPORTES_PARAMETROSRow"/> that 
	/// represents a record in the <c>REPORTES_PARAMETROS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REPORTES_PARAMETROSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPORTES_PARAMETROSRow_Base
	{
		private decimal _id;
		private string _parametros;
		private string _utilizado;
		private System.DateTime _fecha_creacion;
		private bool _fecha_creacionNull = true;
		private string _reutilizable;
		private string _codigo;
		private decimal _reporte_id;
		private bool _reporte_idNull = true;
		private System.DateTime _ultima_utilizacion;
		private bool _ultima_utilizacionNull = true;
		private decimal _usuario_id;
		private string _configuracion;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPORTES_PARAMETROSRow_Base"/> class.
		/// </summary>
		public REPORTES_PARAMETROSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REPORTES_PARAMETROSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PARAMETROS != original.PARAMETROS) return true;
			if (this.UTILIZADO != original.UTILIZADO) return true;
			if (this.IsFECHA_CREACIONNull != original.IsFECHA_CREACIONNull) return true;
			if (!this.IsFECHA_CREACIONNull && !original.IsFECHA_CREACIONNull)
				if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.REUTILIZABLE != original.REUTILIZABLE) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.IsREPORTE_IDNull != original.IsREPORTE_IDNull) return true;
			if (!this.IsREPORTE_IDNull && !original.IsREPORTE_IDNull)
				if (this.REPORTE_ID != original.REPORTE_ID) return true;
			if (this.IsULTIMA_UTILIZACIONNull != original.IsULTIMA_UTILIZACIONNull) return true;
			if (!this.IsULTIMA_UTILIZACIONNull && !original.IsULTIMA_UTILIZACIONNull)
				if (this.ULTIMA_UTILIZACION != original.ULTIMA_UTILIZACION) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.CONFIGURACION != original.CONFIGURACION) return true;
			
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
		/// Gets or sets the <c>PARAMETROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PARAMETROS</c> column value.</value>
		public string PARAMETROS
		{
			get { return _parametros; }
			set { _parametros = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UTILIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UTILIZADO</c> column value.</value>
		public string UTILIZADO
		{
			get { return _utilizado; }
			set { _utilizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get
			{
				if(IsFECHA_CREACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_creacion;
			}
			set
			{
				_fecha_creacionNull = false;
				_fecha_creacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CREACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CREACIONNull
		{
			get { return _fecha_creacionNull; }
			set { _fecha_creacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REUTILIZABLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REUTILIZABLE</c> column value.</value>
		public string REUTILIZABLE
		{
			get { return _reutilizable; }
			set { _reutilizable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPORTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REPORTE_ID</c> column value.</value>
		public decimal REPORTE_ID
		{
			get
			{
				if(IsREPORTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reporte_id;
			}
			set
			{
				_reporte_idNull = false;
				_reporte_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REPORTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREPORTE_IDNull
		{
			get { return _reporte_idNull; }
			set { _reporte_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ULTIMA_UTILIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ULTIMA_UTILIZACION</c> column value.</value>
		public System.DateTime ULTIMA_UTILIZACION
		{
			get
			{
				if(IsULTIMA_UTILIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ultima_utilizacion;
			}
			set
			{
				_ultima_utilizacionNull = false;
				_ultima_utilizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ULTIMA_UTILIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsULTIMA_UTILIZACIONNull
		{
			get { return _ultima_utilizacionNull; }
			set { _ultima_utilizacionNull = value; }
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
		/// Gets or sets the <c>CONFIGURACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONFIGURACION</c> column value.</value>
		public string CONFIGURACION
		{
			get { return _configuracion; }
			set { _configuracion = value; }
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
			dynStr.Append("@CBA@PARAMETROS=");
			dynStr.Append(PARAMETROS);
			dynStr.Append("@CBA@UTILIZADO=");
			dynStr.Append(UTILIZADO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(IsFECHA_CREACIONNull ? (object)"<NULL>" : FECHA_CREACION);
			dynStr.Append("@CBA@REUTILIZABLE=");
			dynStr.Append(REUTILIZABLE);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@REPORTE_ID=");
			dynStr.Append(IsREPORTE_IDNull ? (object)"<NULL>" : REPORTE_ID);
			dynStr.Append("@CBA@ULTIMA_UTILIZACION=");
			dynStr.Append(IsULTIMA_UTILIZACIONNull ? (object)"<NULL>" : ULTIMA_UTILIZACION);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@CONFIGURACION=");
			dynStr.Append(CONFIGURACION);
			return dynStr.ToString();
		}
	} // End of REPORTES_PARAMETROSRow_Base class
} // End of namespace

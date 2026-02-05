-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.6.10


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema maos_voluntarias
--

CREATE DATABASE IF NOT EXISTS maos_voluntarias;
USE maos_voluntarias;

--
-- Definition of procedure `aceitarInscricao`
--

DROP PROCEDURE IF EXISTS `aceitarInscricao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `aceitarInscricao`(vEmail varchar(200), vCodigoEvento int, vCodigoFuncao int)
begin
	update inscricao_evento set ic_aprovado = true where nm_email = vEmail and cd_evento = vCodigoEvento and cd_funcao = vCodigoFuncao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `atualizarVagas`
--

DROP PROCEDURE IF EXISTS `atualizarVagas`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `atualizarVagas`(vCodigoFuncao int, vCodigoEvento int, vVagas int)
begin
	Update funcao_evento set qt_vagas = vVagas where cd_funcao = vCodigoFuncao and cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `avaliarEvento`
--

DROP PROCEDURE IF EXISTS `avaliarEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `avaliarEvento`(vEmail varchar(200), vCodigo int, vQuantidade int, vDescricao text)
begin
insert into avaliacao_evento (nm_email, cd_evento, qt_avaliacao, ds_observacao) 
values (vEmail, vCodigo, vQuantidade, vDescricao);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `avaliarUsuario`
--

DROP PROCEDURE IF EXISTS `avaliarUsuario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `avaliarUsuario`(vEmailEmpresa varchar(200), vEmailUsuario varchar(200) , vCodigo int, vQuantidade varchar(45), vDescricao text)
begin
insert into avaliacao_usuario (nm_email_empresa, nm_email_usuario, cd_funcao, qt_avaliacao, ds_avaliacao) 
values (vEmailEmpresa, vEmailUsuario, vCodigo, vQuantidade, vDescricao);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `banirUsuario`
--

DROP PROCEDURE IF EXISTS `banirUsuario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `banirUsuario`(vEmail varchar(200))
begin
	update usuario set ic_banido = true where nm_email = vEmail;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `buscarDataFim`
--

DROP PROCEDURE IF EXISTS `buscarDataFim`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscarDataFim`(vCodigo int)
Begin
	Select dt_fim from evento where cd_evento = vCodigo;
End $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `buscarEmailEvento`
--

DROP PROCEDURE IF EXISTS `buscarEmailEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscarEmailEvento`(vCodigoEvento int)
begin
	Select nm_email from evento where cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `buscarInfoEmpresa`
--

DROP PROCEDURE IF EXISTS `buscarInfoEmpresa`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscarInfoEmpresa`(vEmail varchar(200))
begin
    select nm_empresa, nm_foto, nm_link_site, nm_telefone, ds_empresa from empresa where nm_email = vEmail;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `buscarInfoUsuario`
--

DROP PROCEDURE IF EXISTS `buscarInfoUsuario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscarInfoUsuario`(vEmail varchar(200))
begin
    select nm_usuario, nm_foto_perfil, ds_usuario from usuario where nm_email = vEmail;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `buscarMinhasInscricoes`
--

DROP PROCEDURE IF EXISTS `buscarMinhasInscricoes`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscarMinhasInscricoes`(vEmail varchar(200))
begin
	select ie.cd_evento, e.nm_evento, f.nm_funcao, f.cd_funcao, ie.ic_aprovado
	from inscricao_evento ie
	join funcao_evento fe ON (ie.cd_funcao = fe.cd_funcao)
	join funcao f ON (fe.cd_funcao = f.cd_funcao)
	join evento e ON (ie.cd_evento = e.cd_evento)
	where ie.nm_email = vEmail and current_date < e.dt_limite_inscricao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `buscarNomeEvento`
--

DROP PROCEDURE IF EXISTS `buscarNomeEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscarNomeEvento`(vCodigo int)
begin
	select nm_evento from evento where cd_evento = vCodigo;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `buscarVagas`
--

DROP PROCEDURE IF EXISTS `buscarVagas`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscarVagas`(vCodigoFuncao int, vCodigoEvento int)
begin
	Select qt_vagas from funcao_evento where cd_funcao = vCodigoFuncao and cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `cadastrarEmpresa`
--

DROP PROCEDURE IF EXISTS `cadastrarEmpresa`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `cadastrarEmpresa`(vEmail varchar(200), vEmpresa varchar(200), vCnpj varchar(25), vTelefone varchar(20), vSite text, vSenha varchar(64))
BEGIN
insert into empresa (nm_email, nm_empresa, cd_cnpj, nm_link_site, nm_telefone, nm_senha, ic_verificado, nm_foto, ic_banido, ds_empresa)
values (vEmail, vEmpresa, vCnpj, vSite, vTelefone, sha(vSenha), true, null, false, '');
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `cadastrarUsuario`
--

DROP PROCEDURE IF EXISTS `cadastrarUsuario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `cadastrarUsuario`(vEmail varchar(200), vUsuario varchar(200), vSenha varchar(64), vFotoPerfil longblob, vCpf varchar(15), vCodigoVerificacao varchar(64), vFotoDocumento longblob, vRG varchar(15))
begin
	insert into usuario (nm_email, nm_usuario, nm_senha, nm_foto_perfil, ic_banido, cd_cpf, cd_verificacao, nm_foto_documento, cd_rg, ic_verificado, cd_tipo_usuario) 
	values (vEmail, vUsuario, vSenha, null, false, vCpf, vCodigoVerificacao, vFotoDocumento, vRG, false, 1);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `calcularMediaAvaliacaoEmpresa`
--

DROP PROCEDURE IF EXISTS `calcularMediaAvaliacaoEmpresa`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `calcularMediaAvaliacaoEmpresa`(vEmail varchar(200))
begin
	select (sum(ae.qt_avaliacao))/(count(ae.qt_avaliacao)) from avaliacao_evento ae
join evento e on (e.cd_evento = ae.cd_evento)
join empresa em on (e.nm_email = em.nm_email) where e.nm_email = vEmail;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `calcularMediaAvaliacaoEvento`
--

DROP PROCEDURE IF EXISTS `calcularMediaAvaliacaoEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `calcularMediaAvaliacaoEvento`(vCodigoEvento varchar(200))
begin
	select sum(qt_avaliacao)/count(qt_avaliacao) from avaliacao_evento where cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `calcularMediaAvaliacaoUsuario`
--

DROP PROCEDURE IF EXISTS `calcularMediaAvaliacaoUsuario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `calcularMediaAvaliacaoUsuario`(vEmail varchar(200))
begin
	select sum(qt_avaliacao)/count(qt_avaliacao) from avaliacao_usuario where nm_email_usuario = vEmail;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `cancelarInscricao`
--

DROP PROCEDURE IF EXISTS `cancelarInscricao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `cancelarInscricao`(vEmail varchar(200), vCodigoFuncao int, vCodigoEvento int)
begin
	delete from inscricao_evento where nm_email = vEmail and cd_funcao = vCodigoFuncao and cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `contarEventosAcontecendo`
--

DROP PROCEDURE IF EXISTS `contarEventosAcontecendo`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `contarEventosAcontecendo`(vEmail varchar(200))
begin
	Select ceiling(count(cd_evento)/4) from evento where nm_email = vEmail and (dt_fim > current_date);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `contarEventosEncerrado`
--

DROP PROCEDURE IF EXISTS `contarEventosEncerrado`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `contarEventosEncerrado`(vEmail varchar(200))
begin
	Select ceiling(count(cd_evento)/4) from evento where nm_email = vEmail and (dt_fim < current_date);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `contarEventosInscrito`
--

DROP PROCEDURE IF EXISTS `contarEventosInscrito`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `contarEventosInscrito`(vEmail varchar(200))
begin
	Select ceiling(count(e.cd_evento)/4) from evento e
	join inscricao_evento ie on (ie.cd_evento = e.cd_evento) 	
	where ie.nm_email = vEmail  and (dt_fim > current_date);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `contarEventosParticipado`
--

DROP PROCEDURE IF EXISTS `contarEventosParticipado`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `contarEventosParticipado`(vEmail varchar(200))
begin
		Select ceiling(count(e.cd_evento)/4) from evento e
	join inscricao_evento ie on (ie.cd_evento = e.cd_evento) 	
	where ie.nm_email = vEmail and (dt_fim < current_date);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `contarInscricoesPendentes`
--

DROP PROCEDURE IF EXISTS `contarInscricoesPendentes`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `contarInscricoesPendentes`(vCodigoEvento varchar(200))
begin
	select count(nm_email) from inscricao_evento where cd_evento = vCodigoEvento and ic_aprovado = false;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `criarEvento`
--

DROP PROCEDURE IF EXISTS `criarEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `criarEvento`(pCodigo int, pNome varchar(255), pDescricao text, pEndereco text, pDataInicio date, pDataFim date, pDataLimite datetime, pImagem longblob, pEmail varchar(200), pCategoria int, pCidade int)
begin
	insert into evento (cd_evento, nm_evento, ds_evento, ds_endereco, dt_inicio, dt_fim, dt_limite_inscricao, nm_imagem, nm_email, cd_categoria_evento, cd_cidade)
	values (pCodigo, pNome, pDescricao, pEndereco, pDataInicio, pDataFim, pDataLimite, pImagem, pEmail, pCategoria, pCidade);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `criarFuncao`
--

DROP PROCEDURE IF EXISTS `criarFuncao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `criarFuncao`(vCodigoFuncao int, vNomeFuncao varchar(200), vCodigoCategoria int, vCodigoEvento int, vDataInicio datetime, vDataFim datetime, vVagas int, vDescricao text)
begin
	insert into funcao (cd_funcao, nm_funcao, cd_categoria_funcao) 
	values (vCodigoFuncao, vNomeFuncao, vCodigoCategoria);
	insert into funcao_evento (cd_funcao, cd_evento, dt_inicio_funcao, dt_fim_funcao, qt_vagas, ds_funcao) 
	values (vCodigoFuncao, vCodigoEvento, vDataInicio, vDataFim, vVagas, vDescricao);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `deletarEvento`
--

DROP PROCEDURE IF EXISTS `deletarEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `deletarEvento`(vCodigoEvento int)
begin
	delete from imagem_evento where cd_evento = vCodigoEvento;
	delete from evento where cd_evento = vCodigoEvento;

end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `deletarFuncao`
--

DROP PROCEDURE IF EXISTS `deletarFuncao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `deletarFuncao`(vCodigoFuncao int)
begin
	Delete from inscricao_evento where cd_funcao = vCodigoFuncao;
	Delete from funcao_evento where cd_funcao = vCodigoFuncao;
	Delete from funcao where cd_funcao = vCodigoFuncao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `deletarFuncoes`
--

DROP PROCEDURE IF EXISTS `deletarFuncoes`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `deletarFuncoes`(vCodigo int)
begin
	delete from funcao where cd_funcao = vCodigo;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `deletarImagemEvento`
--

DROP PROCEDURE IF EXISTS `deletarImagemEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `deletarImagemEvento`(vCodigoImagem int(11))
BEGIN
delete from imagem_evento where cd_imagem = vCodigoImagem;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `desbanirUsuario`
--

DROP PROCEDURE IF EXISTS `desbanirUsuario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `desbanirUsuario`(vEmail varchar(200))
begin
	update usuario set ic_banido = false where nm_email = vEmail;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `editarEvento`
--

DROP PROCEDURE IF EXISTS `editarEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editarEvento`(vCodigo int, vNome varchar(255), vInicio datetime, vFim datetime, vEndereco varchar(200), vCategoria int,vDescricao text)
begin
update evento 
set nm_evento = vNome,
dt_inicio = vInicio,
dt_fim = vFim,
ds_endereco = vEndereco,
cd_categoria_evento = vCategoria,
ds_evento = vDescricao
where cd_evento = vCodigo;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `editarFuncao`
--

DROP PROCEDURE IF EXISTS `editarFuncao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editarFuncao`(vCodigoFuncao int, vNomeFuncao varchar(200), vCodigoCategoria int, vCodigoEvento int, vDataInicio datetime, vDataFim datetime, vVagas int, vDescricao text)
begin
	update funcao set
	nm_funcao = vNomeFuncao,
	cd_categoria_funcao = vCodigoCategoria
	where cd_funcao = vCodigoFuncao;

	update funcao_evento set
	cd_evento = vCodigoEvento,
	dt_inicio_funcao = vDataInicio,
	dt_fim_funcao = vDataFim,
	qt_vagas = vVagas,
	ds_funcao = vDescricao
	where cd_funcao = vCodigoFuncao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `exibeVaga`
--

DROP PROCEDURE IF EXISTS `exibeVaga`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `exibeVaga`(vDataInicio datetime, vCodigoEvento int, vNomeFuncao varchar(200))
begin
	Select dt_fim_funcao, ds_funcao, qt_vagas from funcao_evento fe
	join funcao f on (f.cd_funcao = fe.cd_funcao)
	where (fe.dt_inicio_funcao = vDataInicio) and (fe.cd_evento = vCodigoEvento) and (f.nm_funcao = vNomeFuncao);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarCategoriaEvento`
--

DROP PROCEDURE IF EXISTS `listarCategoriaEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarCategoriaEvento`()
begin
	select * from categoria_evento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarCategoriaFuncao`
--

DROP PROCEDURE IF EXISTS `listarCategoriaFuncao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarCategoriaFuncao`()
begin
	select * from categoria_funcao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarCidades`
--

DROP PROCEDURE IF EXISTS `listarCidades`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarCidades`()
begin
	Select * from cidade;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarConteudoEvento`
--

DROP PROCEDURE IF EXISTS `listarConteudoEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarConteudoEvento`(vCodigoEvento int)
begin
	select evento.nm_evento, evento.ds_evento, evento.ds_endereco, evento.dt_inicio, evento.dt_fim, evento.dt_limite_inscricao, 
	categoria_evento.nm_categoria_evento, categoria_evento.cd_categoria_evento, empresa.nm_empresa, empresa.nm_foto, evento.nm_imagem
	from evento
	join categoria_evento ON (evento.cd_categoria_evento=categoria_evento.cd_categoria_evento)
	join empresa ON (evento.nm_email=empresa.nm_email)
	where evento.cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarEventos`
--

DROP PROCEDURE IF EXISTS `listarEventos`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarEventos`()
begin
	Select evento.cd_evento, evento.nm_evento, evento.dt_inicio, evento.ds_evento, evento.ds_endereco, evento.nm_imagem, empresa.nm_empresa
	from evento join empresa ON (evento.nm_email=empresa.nm_email)
	where e.dt_fim > current_date
	order by dt_limite_inscricao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarEventosAcontecendo`
--

DROP PROCEDURE IF EXISTS `listarEventosAcontecendo`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarEventosAcontecendo`(vEmail varchar(200), vOffset int)
begin
select e.cd_evento, e.nm_evento, e.dt_inicio, e.ds_evento, e.ds_endereco, e.nm_imagem, em.nm_empresa from evento e 
join empresa em on (em.nm_email = e.nm_email)
where e.nm_email = vEmail and (e.dt_fim > current_date) order by dt_inicio limit 4 offset vOffset;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarEventosComFuncao`
--

DROP PROCEDURE IF EXISTS `listarEventosComFuncao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarEventosComFuncao`()
begin
	Select distinct(e.cd_evento) as codigo, e.nm_evento, e.dt_inicio, e.ds_evento, e.ds_endereco, e.nm_imagem, em.nm_empresa from funcao f 
	join funcao_evento fe on f.cd_funcao = fe.cd_funcao
	join evento e on fe.cd_evento = e.cd_evento
	join empresa em on e.nm_email = em.nm_email
	where e.dt_fim > current_date
	order by dt_limite_inscricao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarEventosEncerrados`
--

DROP PROCEDURE IF EXISTS `listarEventosEncerrados`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarEventosEncerrados`(vEmail varchar(200), vOffset int)
begin
select e.cd_evento, e.nm_evento, e.dt_inicio, e.ds_evento, e.ds_endereco, e.nm_imagem, em.nm_empresa from evento e 
join empresa em on (em.nm_email = e.nm_email)
where e.nm_email = vEmail and (e.dt_fim < current_date) order by dt_fim desc limit 4 offset vOffset;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarEventosFiltradosPorBusca`
--

DROP PROCEDURE IF EXISTS `listarEventosFiltradosPorBusca`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarEventosFiltradosPorBusca`(pfiltro varchar(60))
begin
	Select evento.cd_evento, evento.nm_evento, evento.dt_inicio, evento.ds_evento, evento.ds_endereco, evento.nm_imagem, empresa.nm_empresa
	from evento 
	join empresa ON (evento.nm_email=empresa.nm_email)
	join funcao_evento ON (evento.cd_evento = funcao_evento.cd_evento)
	join funcao ON (funcao_evento.cd_funcao = funcao.cd_funcao)
	where evento.nm_evento like CONCAT('%', pFiltro , '%') or empresa.nm_empresa like CONCAT('%', pFiltro , '%') or funcao.nm_funcao like CONCAT('%', pFiltro , '%'); 
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarEventosInscricoesPendentes`
--

DROP PROCEDURE IF EXISTS `listarEventosInscricoesPendentes`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarEventosInscricoesPendentes`(vEmail varchar(200))
begin
select distinct(e.cd_evento), e.nm_evento, e.dt_inicio, e.ds_evento, e.ds_endereco, e.nm_imagem, em.nm_empresa from evento e 
join empresa em on (em.nm_email = e.nm_email)
join inscricao_evento ie on (e.cd_evento = ie.cd_evento)
where e.nm_email = vEmail and (ie.ic_aprovado = false) and (e.dt_fim > current_date)
order by dt_limite_inscricao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarEventosInscrito`
--

DROP PROCEDURE IF EXISTS `listarEventosInscrito`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarEventosInscrito`(vEmail varchar(200), vOffset int)
begin
	select distinct(e.cd_evento), e.nm_evento, e.dt_inicio, e.ds_evento, e.ds_endereco,  e.nm_imagem, em.nm_empresa from evento e
join inscricao_evento ie on (ie.cd_evento = e.cd_evento) 
join empresa em on (em.nm_email = e.nm_email)
where ie.nm_email = vEmail and (e.dt_fim > current_date)  order by dt_inicio limit 4 offset vOffset;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarEventosParticipado`
--

DROP PROCEDURE IF EXISTS `listarEventosParticipado`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarEventosParticipado`(vEmail varchar(200), vOffset int)
begin
	select distinct(e.cd_evento), e.nm_evento, e.dt_inicio, e.ds_evento, e.ds_endereco,  e.nm_imagem, em.nm_empresa from evento e
join inscricao_evento ie on (ie.cd_evento = e.cd_evento) 
join empresa em on (em.nm_email = e.nm_email)
where ie.nm_email = vEmail and (e.dt_fim < current_date) and (ie.ic_aprovado = true) order by dt_fim desc limit 4 offset vOffset;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarFuncoesEvento`
--

DROP PROCEDURE IF EXISTS `listarFuncoesEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarFuncoesEvento`(vCodigoEvento int)
begin
	Select funcao.nm_funcao, funcao_evento.ds_funcao, funcao_evento.dt_inicio_funcao, funcao_evento.dt_fim_funcao, funcao_evento.qt_vagas, funcao_evento.cd_funcao
	from funcao
	join funcao_evento ON (funcao.cd_funcao=funcao_evento.cd_funcao) 
	where funcao_evento.cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarImagensEvento`
--

DROP PROCEDURE IF EXISTS `listarImagensEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarImagensEvento`(vCodigoEvento int)
begin
	select * from imagem_evento where cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarInscricoes`
--

DROP PROCEDURE IF EXISTS `listarInscricoes`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarInscricoes`(vCodigo int)
begin
	select inscricao_evento.nm_email ,usuario.nm_foto_perfil, usuario.nm_usuario, funcao.nm_funcao, funcao.cd_funcao 
	from inscricao_evento
	join usuario ON (inscricao_evento.nm_email = usuario.nm_email)
	join funcao_evento ON (inscricao_evento.cd_funcao = funcao_evento.cd_funcao)
	join funcao ON (funcao_evento.cd_funcao = funcao.cd_funcao)
	where inscricao_evento.cd_evento = vCodigo and inscricao_evento.ic_aprovado = false;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarInscricoesAprovadas`
--

DROP PROCEDURE IF EXISTS `listarInscricoesAprovadas`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarInscricoesAprovadas`(vCodigo int)
begin
	select inscricao_evento.nm_email ,usuario.nm_foto_perfil, usuario.nm_usuario, funcao.nm_funcao, funcao.cd_funcao
	from inscricao_evento
	join usuario ON (inscricao_evento.nm_email = usuario.nm_email)
	join funcao_evento ON (inscricao_evento.cd_funcao = funcao_evento.cd_funcao)
	join funcao ON (funcao_evento.cd_funcao = funcao.cd_funcao)
	where inscricao_evento.cd_evento = vCodigo and inscricao_evento.ic_aprovado = true;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarNomeCategoria`
--

DROP PROCEDURE IF EXISTS `listarNomeCategoria`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarNomeCategoria`(vCodigoCategoria int )
begin
	Select nm_categoria_evento from categoria_evento where cd_categoria_evento = vCodigoCategoria;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarNomeCidade`
--

DROP PROCEDURE IF EXISTS `listarNomeCidade`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarNomeCidade`(vCodigoCidade int)
begin
	Select nm_cidade from cidade where cd_cidade = vCodigoCidade;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarNomeHabilidade`
--

DROP PROCEDURE IF EXISTS `listarNomeHabilidade`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarNomeHabilidade`(vCodigoHabilidade int)
begin
	Select nm_categoria_funcao from categoria_funcao where cd_categoria_funcao = vCodigoHabilidade;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarNotaAvaliacao`
--

DROP PROCEDURE IF EXISTS `listarNotaAvaliacao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarNotaAvaliacao`(vEmail varchar(200))
begin
	select qt_avaliacao from avaliacao_usuario where nm_email_usuario = vEmail;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarPaginaEvento`
--

DROP PROCEDURE IF EXISTS `listarPaginaEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarPaginaEvento`(vCodigoEvento int)
begin
	select funcao.nm_funcao, funcao_evento.ds_funcao, funcao_evento.dt_inicio_funcao, funcao_evento.dt_fim_funcao, funcao_evento.qt_vagas, evento.nm_evento, 
	evento.ds_evento, evento.ds_endereco, evento.dt_inicio, evento.dt_fim, evento.dt_limite_inscricao, categoria_evento.nm_categoria_evento, categoria_evento.cd_categoria_evento,
	empresa.nm_empresa
	from funcao 
	join funcao_evento ON (funcao.cd_funcao=funcao_evento.cd_funcao) 
	join evento ON (funcao_evento.cd_evento=evento.cd_evento) 
	join categoria_evento ON (evento.cd_categoria_evento=categoria_evento.cd_categoria_evento)
	join empresa ON (evento.nm_email=empresa.nm_email)
	where funcao_evento.cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `listarTodosEventosEncerrados`
--

DROP PROCEDURE IF EXISTS `listarTodosEventosEncerrados`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTodosEventosEncerrados`(vEmail varchar(200))
begin
select e.cd_evento, e.nm_evento, e.dt_inicio, e.ds_evento, e.ds_endereco, e.nm_imagem, em.nm_empresa from evento e 
join empresa em on (em.nm_email = e.nm_email)
where e.nm_email = vEmail and (e.dt_fim < current_date) order by dt_fim desc;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `logar`
--

DROP PROCEDURE IF EXISTS `logar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `logar`(vEmail varchar(200), vSenha varchar(64))
begin
    select nm_usuario, cd_cpf from usuario where nm_email = vEmail and nm_senha = sha(vSenha)
    union
    select nm_empresa, cd_cnpj from empresa where nm_email = vEmail and nm_senha = sha(vSenha);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `pegarCodigoCategoriaFuncao`
--

DROP PROCEDURE IF EXISTS `pegarCodigoCategoriaFuncao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `pegarCodigoCategoriaFuncao`(vCodigoEvento int(11))
BEGIN
select f.cd_categoria_funcao from funcao_evento fe join funcao f on fe.cd_funcao = f.cd_funcao where cd_evento = vCodigoEvento;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `pegarFotoPerfil`
--

DROP PROCEDURE IF EXISTS `pegarFotoPerfil`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `pegarFotoPerfil`(vEmail varchar(200))
begin
    select nm_foto_perfil from usuario where nm_email = vEmail
    union
    select nm_foto from empresa where nm_email = vEmail;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `procurarEventoAvaliacaoPendente`
--

DROP PROCEDURE IF EXISTS `procurarEventoAvaliacaoPendente`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `procurarEventoAvaliacaoPendente`(vEmail varchar(200))
begin
Select evento.cd_evento, evento.nm_evento, empresa.nm_empresa, empresa.nm_foto from evento
join inscricao_evento on (inscricao_evento.cd_evento = evento.cd_evento) 
join empresa on (empresa.nm_email = evento.nm_email)
where inscricao_evento.nm_email = vEmail and (evento.dt_fim < current_date) and (inscricao_evento.ic_aprovado = 1);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `procurarInscricaoUsuario`
--

DROP PROCEDURE IF EXISTS `procurarInscricaoUsuario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `procurarInscricaoUsuario`(vEmail varchar(200), vCodigoEvento int, vCodigoFuncao int, vDataInicio datetime)
begin
	Select ie.*, f.nm_funcao from inscricao_evento ie
join funcao f on (f.cd_funcao = ie.cd_funcao)
where nm_email = vEmail and cd_evento = vCodigoEvento and ie.cd_funcao = vCodigoFuncao and dt_inicio_funcao = vDataInicio;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `procurarQuantidadeVagas`
--

DROP PROCEDURE IF EXISTS `procurarQuantidadeVagas`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `procurarQuantidadeVagas`(vCodigoEvento int, vCodigoFuncao int)
begin
	select qt_vagas from funcao_evento where cd_funcao = vCodigoFuncao and cd_evento = vCodigoEvento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `proximaFuncao`
--

DROP PROCEDURE IF EXISTS `proximaFuncao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proximaFuncao`()
begin
	Select max(cd_funcao)+1 from funcao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `proximoEvento`
--

DROP PROCEDURE IF EXISTS `proximoEvento`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proximoEvento`()
begin
	Select max(cd_evento)+1 from evento;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `recusarInscricao`
--

DROP PROCEDURE IF EXISTS `recusarInscricao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `recusarInscricao`(vEmail varchar(200), vCodigoEvento int, vCodigoFuncao int)
begin 
	Delete from inscricao_evento where nm_email = vEmail and cd_evento = vCodigoEvento and cd_funcao = vCodigoFuncao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `selecionarCodigoFuncoes`
--

DROP PROCEDURE IF EXISTS `selecionarCodigoFuncoes`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `selecionarCodigoFuncoes`()
begin
	Select cd_funcao from funcao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `solicitarInscricao`
--

DROP PROCEDURE IF EXISTS `solicitarInscricao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `solicitarInscricao`(vEmail varchar(200), vCodigoFuncao int, vCodigoEvento int, vDataInicio datetime)
begin
	insert into inscricao_evento (nm_email, cd_funcao, cd_evento, dt_inicio_funcao, dt_inscricao, ic_aprovado) 
	values (vEmail, vCodigoFuncao, vCodigoEvento, vDataInicio, current_timestamp, false);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `verificaEmail`
--

DROP PROCEDURE IF EXISTS `verificaEmail`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `verificaEmail`(vEmail varchar(200))
BEGIN
select nm_email from usuario where nm_email = vEmail
union
select nm_email from empresa where nm_email = vEmail;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `verificarAprovacao`
--

DROP PROCEDURE IF EXISTS `verificarAprovacao`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `verificarAprovacao`(vEmail varchar(200), vCodigoEvento int, vCodigoFuncao int)
begin
	select ic_aprovado from inscricao_evento where nm_email= vEmail and cd_evento = vCodigoEvento and cd_funcao = vCodigoFuncao;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `verificarAvaliacaoEmpresaExistente`
--

DROP PROCEDURE IF EXISTS `verificarAvaliacaoEmpresaExistente`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `verificarAvaliacaoEmpresaExistente`(vEmail varchar(200), vCodigo int)
begin
Select * from avaliacao_evento where nm_email = vEmail and cd_evento = vCodigo;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `verificarAvaliacaoExistente`
--

DROP PROCEDURE IF EXISTS `verificarAvaliacaoExistente`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `verificarAvaliacaoExistente`(vCodigoFuncao int, vEmail varchar(200))
Begin
Select * from avaliacao_usuario where nm_email_usuario = vEmail and cd_funcao = vCodigoFuncao;
End $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `verificarDono`
--

DROP PROCEDURE IF EXISTS `verificarDono`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `verificarDono`(vEmail varchar(200), vCodigo int)
begin
	select nm_evento from evento where (nm_email = vEmail) and (cd_evento = vCodigo);
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `verificarUsuario`
--

DROP PROCEDURE IF EXISTS `verificarUsuario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `verificarUsuario`(vEmail varchar(200))
begin
	update usuario set ic_verificado = true where nm_email = vEmail;
end $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;

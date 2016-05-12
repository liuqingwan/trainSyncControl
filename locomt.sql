/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50704
Source Host           : localhost:3306
Source Database       : sys

Target Server Type    : MYSQL
Target Server Version : 50704
File Encoding         : 65001

Date: 2016-05-12 23:10:04
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for locomt
-- ----------------------------
DROP TABLE IF EXISTS `locomt`;
CREATE TABLE `locomt` (
  `locoid` int(10) NOT NULL,
  `ipa` varchar(16) DEFAULT NULL,
  `groupid` int(10) DEFAULT '0',
  PRIMARY KEY (`locoid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of locomt
-- ----------------------------

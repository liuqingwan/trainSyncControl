/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50704
Source Host           : localhost:3306
Source Database       : sys

Target Server Type    : MYSQL
Target Server Version : 50704
File Encoding         : 65001

Date: 2016-05-12 23:09:58
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for locogroup
-- ----------------------------
DROP TABLE IF EXISTS `locogroup`;
CREATE TABLE `locogroup` (
  `groupid` int(10) NOT NULL,
  `locoid` int(10) DEFAULT NULL,
  `master` int(10) DEFAULT NULL,
  `loconum` int(10) DEFAULT NULL,
  KEY `head` (`master`),
  KEY `train` (`locoid`),
  CONSTRAINT `head` FOREIGN KEY (`master`) REFERENCES `locomt` (`locoid`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `train` FOREIGN KEY (`locoid`) REFERENCES `locomt` (`locoid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of locogroup
-- ----------------------------

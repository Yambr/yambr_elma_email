<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>f1254386-a72a-4f41-9986-8060c7dae23a</Uid>
  <Name>ContractorExt</Name>
  <DisplayName>ContractorExt</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <BaseClassUid>38096146-0c73-4809-94f5-e18b2d525531</BaseClassUid>
  <Properties>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>f296ac2f-83c2-45e6-8357-4e0f36b42043</Uid>
      <Name>Domains</Name>
      <DisplayName>Домены</DisplayName>
      <Description>письма с этих доменов автоматически создадут новые контакты и прикрепят к ним новые письма</Description>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>9634d99b-edd4-45fe-9b2e-0dc68465bcc0</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <RelationType>OneToMany</RelationType>
        <KeyColumnUid>58c867aa-df79-4795-b3a4-8be6fb9b740c</KeyColumnUid>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>0</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
  </Properties>
  <TableViews>
    <TableView>
      <Uid>e7c98776-cd21-43f9-9290-b27741b61630</Uid>
      <ViewType>List</ViewType>
    </TableView>
  </TableViews>
  <Type>InterfaceExtension</Type>
  <ImplementationUid>88daecfa-09ba-4e4c-85ba-97878639bbc0</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>ContractorExt</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <Actions />
</Entity>
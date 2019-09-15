<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>1a90b668-9e2b-4ac6-8e5f-e1076001ceca</Uid>
  <Name>UserExt</Name>
  <DisplayName>UserExt</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <BaseClassUid>cfdeb03c-35e9-45e7-aad8-037d83888f73</BaseClassUid>
  <Properties>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>f18d2967-d7d1-43a9-be82-8ff0d7fe70e3</Uid>
      <Name>UserMailBoxes</Name>
      <DisplayName>Почтовые ящики</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>06aeb963-e379-4fff-9951-de6bf6cb508f</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <RelationType>OneToMany</RelationType>
        <KeyColumnUid>e11d2fdd-fb0e-4449-822b-cd42d10104ea</KeyColumnUid>
        <CascadeMode>SaveUpdate</CascadeMode>
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
      <Uid>2eaa076a-3c1a-4be2-b6ee-f730b9aedeb5</Uid>
      <ViewType>List</ViewType>
    </TableView>
  </TableViews>
  <Type>InterfaceExtension</Type>
  <ImplementationUid>10b7a75e-293f-4afb-8c10-e31bef75e3df</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>UserExt</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <Actions />
</Entity>